using EIP.Common.DataAccess;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Config
{
    /// <summary>
    ///     ��¼�õ�Ƭ���ݷ��ʽӿ�ʵ��
    /// </summary>
    public class SystemLoginSlideRepository : DapperAsyncRepository<SystemLoginSlide>, ISystemLoginSlideRepository
    {
    }
}