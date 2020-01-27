using MySpace.ApplicationCore.Entities.TPAppsAggregate;
using MySpace.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySpace.ApplicationCore.Services
{
    /// <summary>
    /// 第三方应用密码管理服务
    /// </summary>
    public class AppService //: IAppService
    {
        private readonly IRepository<TPApp> _tpAppRepository;
        private readonly IAppLogger<AppService> _logger;
        public AppService(IRepository<TPApp> tpAppRepository)
        {
            _tpAppRepository = tpAppRepository;
        }

        /// <summary>
        /// 创建一个应用
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="remark"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task CreateAppAsync(string appName, string remark, string password)
        {
            var utcNow = DateTime.UtcNow;
            TPApp entity = new TPApp
            {
                Name = appName,
                Password = new TPAppPassword
                {
                    ExpiredTime = utcNow.AddDays(30),
                    // TODO：暂不处理，使用明文
                    CurrentPasswordHash = password,
                    LastPasswordHash = null,
                    CreateTime = utcNow,
                    ModifyTime = utcNow
                },
                Remark = remark,
                CreateTime = utcNow,
                ModifyTime = utcNow
            };
            await _tpAppRepository.AddAsync(entity);
        }
    }
}
