﻿using System;
using System.Data;
using System.Diagnostics;
using System.Text;
using Quartz;
using System.Configuration;
using System.Threading;
using Common.Logging;
using Common.Logging.Log4Net;
using HiDM.FactoryWorks.TibcoRV;
using HiDM.FactoryWorks.Messages;
using HiDM.FactoryWorks.Common;
using HiDM.SMFG.Common;
using System.Text.RegularExpressions;

namespace EIP.Job.Service.System
{
    /// <summary>
    /// 数据库定时备份作业
    /// </summary>
    [DisallowConcurrentExecutionAttribute]
    public class StepAutoJob : IJob
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                //IJobExecutionContext msg = context;
                LogManager.GetLogger("StepAutoJob").Debug("Executed");

                MessageService.Initialize();

                if (lot_prepar(context) == true)
                {
                    if (lot_Jobin(context) == true)
                    {
                        if (lot_Jobout(context) == true)
                        {
                            if (lot_backup(context) == true)
                            {
                                LogManager.GetLogger("StepAutoJob").Debug("Sucess");
                            };
                        };
                    };
                };



            }
            catch (Exception EX)
            {

            }

            finally 
            {
                MessageService.Terminate();
            }
        }


        public class Action : BaseFWReqMessage
        {
            public Action(string Trans)
                : base(Trans)
            {
            }
        }


        public string Substring(string text, string start, string end)
        {
            //int IndexofA = text.IndexOf(start);
            //int IndexofB = text.IndexOf(end);
            //string NameText = text.Substring(IndexofA + start.Length, IndexofB - IndexofA + 2 - end.Length);

            Regex rg = new Regex("(?<=(" + start + "))[.\\s\\S]*?(?=(" + end + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            string NameText = rg.Match(text).Value;
            return NameText;
        }

        private void SendEmail(string emailto, string name, string message, string body,string flag)
        {
            if (flag == "Y")
            {
                /*邮件头*/
                string configSubject = ConfigurationManager.AppSettings["emailSubject"].ToString();
                configSubject = configSubject.Replace("$ServiceName", name);
                configSubject = configSubject.Replace("$CurrentTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                /*邮件体*/
                string configBody = ConfigurationManager.AppSettings["emailBody"].ToString();
                configBody = configBody.Replace("$ServiceName", name);
                configBody = configBody.Replace("$CurrentTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                configBody = configBody.Replace("$EXMessage", message);
                configBody = configBody.Replace("$EXBody", body);

                if (emailto == string.Empty)
                {
                    EmailSender.Send(configSubject, configBody, false);
                }
                else
                {
                    EmailSender.Send(emailto, configSubject, configBody, false);
                }
            }
                    
        
        }



        private bool lot_prepar(IJobExecutionContext context)
        {
            try
            {
                JobDataMap data = context.JobDetail.JobDataMap;
                Action msg = new Action(FWMessageSet.C_JOBPREPLOT);

                msg.AddtionalParams.Add("USERID", data.GetString("P_USERID"));
                msg.AddtionalParams.Add("EQPID", data.GetString("P_EQPID"));
                msg.AddtionalParams.Add("CARRIERID", data.GetString("P_CARRIERID"));
                msg.AddtionalParams.Add("BATCHSIZE", data.GetString("P_BATCHSIZE"));
                //start 特殊处理 "TST00523", "LOTID=LWF0002 LOTCOUNT=1 RETICLEID= RETICLESTATE="
                string[] sCarrinfo=data.GetString("P_CARRINFO").Split(';');
                msg.AddtionalParams.Add(sCarrinfo[0], sCarrinfo[1]);
                // end
                //start "LWF0002", "PORTID=AEPL01-LP1 PLANID=01AK2BSS24L1P1M2C01_AA.0 STEPID=AP19AAET01.0 STEPSEQ=170 PPID=PBSI0-AAA01 RETICLEID= RETICLESTATE= RTDPRIORITY= DISPATCHORDER=1"
                string[] sLotinfo = data.GetString("P_LOTINFO").Split(';');
                msg.AddtionalParams.Add(sLotinfo[0], sLotinfo[1]);
                // end
                msg.AddtionalParams.Add("ENGINEERJIPFLAG", data.GetString("P_ENGINEERJIPFLAG"));
                msg.AddtionalParams.Add("SAVEHISTORY", data.GetString("P_SAVEHISTORY"));
                msg.AddtionalParams.Add("PUBLISHCHANGE", data.GetString("P_PUBLISHCHANGE"));
                msg.AddtionalParams.Add("COMMENT", data.GetString("P_COMMENT"));
                msg.AddtionalParams.Add("SAMEPPARM", data.GetString("P_SAMEPPARM"));

                //msg.AddtionalParams.Add("USERID", "E100812");
                //msg.AddtionalParams.Add("EQPID", "AEPL01");
                //msg.AddtionalParams.Add("CARRIERID", "TST00523");
                //msg.AddtionalParams.Add("BATCHSIZE", "1");
                //msg.AddtionalParams.Add("TST00523", "LOTID=LWF0002 LOTCOUNT=1 RETICLEID= RETICLESTATE=");
                //msg.AddtionalParams.Add("LWF0002", "PORTID=AEPL01-LP1 PLANID=01AK2BSS24L1P1M2C01_AA.0 STEPID=AP19AAET01.0 STEPSEQ=170 PPID=PBSI0-AAA01 RETICLEID= RETICLESTATE= RTDPRIORITY= DISPATCHORDER=1");
                //msg.AddtionalParams.Add("ENGINEERJIPFLAG", "F");
                //msg.AddtionalParams.Add("SAVEHISTORY", "T");
                //msg.AddtionalParams.Add("PUBLISHCHANGE", "F");
                //msg.AddtionalParams.Add("COMMENT", "AUTO RUN TEST");
                //msg.AddtionalParams.Add("SAMEPPARM", "T");

                string rtnResult = MessageService.SendRequest(msg.ToString());

                //BaseRepMessage repmsg = new FWTxnRepMessage()
                //{
                //    DisplayData = rtnResult
                //};

                if (Substring(rtnResult, "//l ", " ") != "0")//错误邮件发送
                {
                    string errmsg = Substring(rtnResult, "error={ ", " }");
                    SendEmail(data.GetString("EmailTo"), FWMessageSet.C_JOBPREPLOT, "", errmsg, data.GetString("SendEmail"));

                    return false;
                }
                else
                {
                    return true;
                }

                //return repmsg.IsSuccess;
            }
            catch (Exception ex)
            {
                //错误邮件发送
                SendEmail("", "JOBPREPLOTRULE", ex.Message, ex.StackTrace,"Y");
                
                return false;
            }


        }


        private bool lot_Jobin(IJobExecutionContext context)
        {
            try
            {
                JobDataMap data = context.JobDetail.JobDataMap;
                Action msg = new Action(FWMessageSet.C_JOBINLOT);

                msg.AddtionalParams.Add("USERID", data.GetString("P_USERID"));
                msg.AddtionalParams.Add("EQPID", data.GetString("P_EQPID"));
                msg.AddtionalParams.Add("CARRIERID", data.GetString("P_CARRIERID"));
                msg.AddtionalParams.Add("BATCHSIZE", data.GetString("P_BATCHSIZE"));
                //start 特殊处理 "TST00523", "LOTID=LWF0002 LOTCOUNT=1"
                string[] sCarrinfo = data.GetString("InOut_CARRINFO").Split(';');
                msg.AddtionalParams.Add(sCarrinfo[0], sCarrinfo[1]);
                // end
                //start "LWF0002", "PORTID=AEPL01-LP1 PLANID=01AK2BSS24L1P1M2C01_AA.0 STEPID=AP19AAET01.0 STEPSEQ=170 PPID=PBSI0-AAA01"
                string[] sLotinfo = data.GetString("In_LOTINFO").Split(';');
                msg.AddtionalParams.Add(sLotinfo[0], sLotinfo[1]);
                // end
                msg.AddtionalParams.Add("SAVEHISTORY", data.GetString("P_SAVEHISTORY"));
                msg.AddtionalParams.Add("PUBLISHCHANGE", data.GetString("P_PUBLISHCHANGE"));
                msg.AddtionalParams.Add("COMMENT", data.GetString("P_COMMENT"));

                //msg.AddtionalParams.Add("USERID", "E100812");
                //msg.AddtionalParams.Add("EQPID", "AEPL01");
                //msg.AddtionalParams.Add("CARRIERID", "TST00523");
                //msg.AddtionalParams.Add("BATCHSIZE", "1");
                //msg.AddtionalParams.Add("TST00523", "LOTID=LWF0002 LOTCOUNT=1");
                //msg.AddtionalParams.Add("LWF0002", "PORTID=AEPL01-LP1 PLANID=01AK2BSS24L1P1M2C01_AA.0 STEPID=AP19AAET01.0 STEPSEQ=170 PPID=PBSI0-AAA01");
                //msg.AddtionalParams.Add("SAVEHISTORY", "T");
                //msg.AddtionalParams.Add("PUBLISHCHANGE", "F");
                //msg.AddtionalParams.Add("COMMENT", "AUTO RUN TEST");

                string rtnResult = MessageService.SendRequest(msg.ToString());

                //BaseRepMessage repmsg = new FWTxnRepMessage()
                //{
                //    DisplayData = rtnResult
                //};

                if (Substring(rtnResult, "//l ", " ") != "0")//错误邮件发送
                {
                    string errmsg = Substring(rtnResult, "error={ ", " }");
                    SendEmail(data.GetString("EmailTo"), FWMessageSet.C_JOBINLOT, "", errmsg, data.GetString("SendEmail"));

                    return false;
                }
                else
                {
                    return true;
                }

                //return repmsg.IsSuccess;
            }
            catch (Exception ex)
            {
                //错误邮件发送
                SendEmail("", "JOBINLOTRULE", ex.Message, ex.StackTrace,"Y");

                return false;
            }

        }

        private bool lot_Jobout(IJobExecutionContext context)
        {
            try
            {
                JobDataMap data = context.JobDetail.JobDataMap;
                Action msg = new Action(FWMessageSet.C_JOBOUTLOT);

                msg.AddtionalParams.Add("USERID", data.GetString("P_USERID"));
                msg.AddtionalParams.Add("EQPID", data.GetString("P_EQPID"));
                msg.AddtionalParams.Add("SUBEQPID", data.GetString("Out_SUBEQPID"));
                msg.AddtionalParams.Add("CARRIERID", data.GetString("P_CARRIERID"));
                msg.AddtionalParams.Add("BATCHSIZE", data.GetString("P_BATCHSIZE"));
                //start 特殊处理 "TST00523", "LOTID=LWF0002 LOTCOUNT=1"
                string[] sCarrinfo = data.GetString("InOut_CARRINFO").Split(';');
                msg.AddtionalParams.Add(sCarrinfo[0], sCarrinfo[1]);
                // end
                //start"LWF0002", "PLANID=01AK2BSS24L1P1M2C01_AA.0 STEPID=AP19AAET01.0 STEPSEQ=170 PPID=PBSI0-AAA01"
                string[] sLotinfo = data.GetString("Out_LOTINFO").Split(';');
                msg.AddtionalParams.Add(sLotinfo[0], sLotinfo[1]);
                // end
                msg.AddtionalParams.Add("SAVEHISTORY", data.GetString("P_SAVEHISTORY"));
                msg.AddtionalParams.Add("PUBLISHCHANGE", data.GetString("P_PUBLISHCHANGE"));
                msg.AddtionalParams.Add("COMMENT", data.GetString("P_COMMENT"));

                //msg.AddtionalParams.Add("USERID", "E100812");
                //msg.AddtionalParams.Add("EQPID", "AEPL01");
                //msg.AddtionalParams.Add("SUBEQPID", "");  
                //msg.AddtionalParams.Add("BATCHSIZE", "1");
                //msg.AddtionalParams.Add("CARRIERID", "TST00523");
                //msg.AddtionalParams.Add("TST00523", "LOTID=LWF0002 LOTCOUNT=1");
                //msg.AddtionalParams.Add("LWF0002", "PLANID=01AK2BSS24L1P1M2C01_AA.0 STEPID=AP19AAET01.0 STEPSEQ=170 PPID=PBSI0-AAA01");
                //msg.AddtionalParams.Add("SAVEHISTORY", "T");
                //msg.AddtionalParams.Add("PUBLISHCHANGE", "F");
                //msg.AddtionalParams.Add("COMMENT", "AUTO RUN TEST");

                string rtnResult = MessageService.SendRequest(msg.ToString());

                //BaseRepMessage repmsg = new FWTxnRepMessage()
                //{
                //    DisplayData = rtnResult
                //};

                if (Substring(rtnResult, "//l ", " ") != "0")//错误邮件发送
                {
                    string errmsg = Substring(rtnResult, "error={ ", " }");
                    SendEmail(data.GetString("EmailTo"), FWMessageSet.C_JOBOUTLOT, "", errmsg, data.GetString("SendEmail"));

                    return false;
                }
                else
                {
                    return true;
                }

                //return repmsg.IsSuccess;
            }
            catch (Exception ex)
            {
                //错误邮件发送
                SendEmail("", "JOBOUTLOTRULE", ex.Message, ex.StackTrace,"Y");

                return false;
            }

        }

        private bool lot_backup(IJobExecutionContext context)
        {
            try
            {
                JobDataMap data = context.JobDetail.JobDataMap;
                Action msg = new Action(FWMessageSet.C_BACKUPLOT);
                msg.AddtionalParams.Add("USERID", data.GetString("P_USERID"));
                msg.AddtionalParams.Add("CURRENTSTEPID", data.GetString("Backup_CURRENTSTEPID"));
                msg.AddtionalParams.Add("CURRENTSTEPSEQ", data.GetString("Backup_CURRENTSTEPSEQ"));
                msg.AddtionalParams.Add("CURRENTPLANID", data.GetString("Backup_CURRENTPLANID"));
                msg.AddtionalParams.Add("CARRIERID", data.GetString("P_CARRIERID"));
                msg.AddtionalParams.Add("LOTID", data.GetString("Backup_LOTID"));
                msg.AddtionalParams.Add("NEWSTEPID", data.GetString("Backup_NEWSTEPID"));
                msg.AddtionalParams.Add("NEWSTEPSEQ", data.GetString("Backup_NEWSTEPSEQ"));
                msg.AddtionalParams.Add("NEXTSTEPDESC", data.GetString("Backup_NEXTSTEPDESC"));
                msg.AddtionalParams.Add("COMMENT", data.GetString("P_COMMENT"));
                msg.AddtionalParams.Add("SAVEHISTORY", data.GetString("P_SAVEHISTORY"));
                msg.AddtionalParams.Add("PUBLISHCHANGE", data.GetString("P_PUBLISHCHANGE"));

                //msg.AddtionalParams.Add("USERID", "E100812");
                //msg.AddtionalParams.Add("CURRENTSTEPID", "AP19AAPC02.0");
                //msg.AddtionalParams.Add("CURRENTSTEPSEQ", "180");
                //msg.AddtionalParams.Add("CURRENTPLANID", "01AK2BSS24L1P1M2C01_AA.0");
                //msg.AddtionalParams.Add("CARRIERID", "TST00523");
                //msg.AddtionalParams.Add("LOTID", "LWF0002");
                //msg.AddtionalParams.Add("NEWSTEPID", "AP19AAET01.0");
                //msg.AddtionalParams.Add("NEWSTEPSEQ", "170");
                //msg.AddtionalParams.Add("NEXTSTEPDESC", "AA Etch");
                //msg.AddtionalParams.Add("COMMENT", "AUTO RUN TEST");
                //msg.AddtionalParams.Add("PUBLISHCHANGE", "F");
                //msg.AddtionalParams.Add("SAVEHISTORY", "T");

                string rtnResult = MessageService.SendRequest(msg.ToString());

                //BaseRepMessage repmsg = new FWTxnRepMessage()
                //{
                //    DisplayData = rtnResult
                //};

                if (Substring(rtnResult, "//l ", " ") != "0")//错误邮件发送
                {
                    string errmsg = Substring(rtnResult, "error={ ", " }");
                    SendEmail(data.GetString("EmailTo"), FWMessageSet.C_BACKUPLOT, "", errmsg,data.GetString("SendEmail"));

                    return false;
                }
                else
                {
                    return true;
                }

                //return repmsg.IsSuccess;
            }
            catch (Exception ex)
            {
                //错误邮件发送
                SendEmail("","BACKUPLOTRULE", ex.Message, ex.StackTrace,"Y");

                return false;
            }

        }
        
    }
}