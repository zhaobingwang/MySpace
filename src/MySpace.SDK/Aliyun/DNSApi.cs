using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.Aliyun
{
    public class DNSApi
    {
        private string accessKeyId;
        private string accessSecret;
        private string regionId = "cn-hangzhou";

        IClientProfile profile;
        DefaultAcsClient defaultClient;

        /// <summary>
        /// 阿里云DNF接口
        /// </summary>
        /// <param name="accessKeyId"></param>
        /// <param name="accessSecret"></param>
        /// <param name="domainName"></param>
        public DNSApi(string accessKeyId, string accessSecret)
        {
            this.accessKeyId = accessKeyId;
            this.accessSecret = accessSecret;
        }

        /// <summary>
        /// 阿里云DNS接口
        /// </summary>
        /// <param name="accessKeyId"></param>
        /// <param name="accessSecret"></param>
        /// <param name="domainName"></param>
        /// <param name="regionId"></param>
        public DNSApi(string accessKeyId, string accessSecret, string regionId) : this(accessKeyId, accessSecret)
        {
            this.regionId = regionId;
        }

        //public DNSApi(string accessKeyId, string accessSecret, string regionId, string domainName,) : this(accessKeyId, accessSecret, domainName, regionId)
        //{
        //    this.regionId = regionId;
        //}

        /// <summary>
        /// 获取解析记录列表
        /// </summary>
        /// <param name="domainName"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DescribeDomainRecordsResponse GetDomainRecords(string domainName, long pageNumber, long pageSize = 20)
        {
            profile = DefaultProfile.GetProfile(regionId, accessKeyId, accessSecret);
            defaultClient = new DefaultAcsClient(profile);

            var request = new DescribeDomainRecordsRequest();
            request.DomainName = domainName;
            request.PageNumber = pageNumber;
            request.PageSize = pageSize;
            var response = defaultClient.GetAcsResponse(request);
            return response;
        }

        /// <summary>
        /// 添加域名解析
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public AddDomainRecordResponse AddDomainRecord(string domainName, string hostRecord,string ip,string type)
        {
            profile = DefaultProfile.GetProfile(domainName, accessKeyId, accessSecret);
            defaultClient = new DefaultAcsClient(profile);

            var request = new AddDomainRecordRequest();
            request.DomainName = domainName;
            request.RR = hostRecord;
            request._Value = ip;
            request.Type = type;
            var response = defaultClient.GetAcsResponse(request);
            return response;
        }
    }
}