using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.DataAccess;
using EIP.Common.Entities.Paging;
using HiDM.FactoryWorks.TibcoRV;
using HiDM.Reporting.Models;
using HiDM.FactoryWorks.Messages;
using HiDM.FactoryWorks.TibcoRV;

namespace HiDM.Reporting.Business.Demo
{
    public class MultiReleaseLotLogic:IMultiReleaseLotLogic
    {
        private ILotHoldInfoRepository _HoldLotInfoRepository;

        public MultiReleaseLotLogic(ILotHoldInfoRepository holdLotInfoRepository)
        {
            _HoldLotInfoRepository = holdLotInfoRepository;
        }

        public async Task<PagedResults> QueryLotHoldInfo(Models.LotHoldInfoInput input)
        {
          var pageResults = await _HoldLotInfoRepository.GetHoldInfoList(input);
          pageResults.ExtraDatas.Add("Summary",await _HoldLotInfoRepository.GetHoldSummary(input));
          return pageResults;
        }

        public async Task<IList<BaseHoldInfo>> ReleaseLots(ReleaseLotInput input)
        {
            foreach (var item in input.HoldInfoList)
            {
                await Task.Factory.StartNew(() => ReleaseLot(item, input.UserID, input.Comments, input.ReleaseReson));
            }

            return input.HoldInfoList;
        }

        private void ReleaseLot(BaseHoldInfo item, string userID, string Comment,string releaseReason)
        {
            var message = new RELEASELOTRULE()
            {
                CarrierID = item.CarrierID,
                LotID = item.LotID,
                HoldCode = item.HoldReason,
                HodeType = item.HoldType,
                UserID = userID,
                SaveHistory = true,
                Comment = Comment,
                ReleaseReason = releaseReason
            };

            var result =  MessageService.SendRequest(message.ToString());

            FWTxnRepMessage rplMsg = new FWTxnRepMessage()
            {
                RepliedString = result
            };

            if (rplMsg.IsSuccess)
            {
                item.Result = true;
            }
            else
            {
                item.Result = false;
                item.ErrorMsg = rplMsg.ErrorMessage;
            }

        }
    }
}
