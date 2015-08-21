using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NodaTime;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using WebApplication5.ServiceModel;
using WebApplication5.ServiceModel.Models;

namespace WebApplication5.ServiceInterface
{
    public class MyServices : Service
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(MyServices));
        public object Any(Hello request)
        {
            //Issue 1 
            
            //This now fails. 
            var campaign = new Campaign();
            campaign.TrackingId = 0;
            campaign.CampaignPhone = "none";
            campaign.CostAmount = 0M;
            campaign.EndDate = 0L;
            campaign.StartDate = SystemClock.Instance.Now.Ticks / NodaConstants.TicksPerMillisecond;
            campaign.FixedCost = 0M;
            campaign.IsActive = true;
            campaign.IsRetread = true;
            campaign.IsFactorTrustApp = true;
            campaign.IsFactorTrustLeads = true;
            campaign.IsDuplicate = true;
            campaign.IsEmail = true;
            campaign.MasterId = 0;
            campaign.IsFirmOffer = false;
            campaign.LeadDelCostTypeId = 0;
            campaign.LeadDelRespTypeId = 0;
            campaign.LeadDelTypeId = 0;
            campaign.LeadRoutingTypeId = 0;
            campaign.Name = "Exception Campaign";
            campaign.IsExceptionCampaign = true;
            campaign.IsDefaultCampaign = false;
            campaign.IsActive = true;

            var rowId = Db.Insert(campaign, true);
            


            //Issue 2


            // This is also broken

/*            var campaigns = Db.Dictionary<int, string>(Db.
                    From<Campaign>().
                    Select(x => new { x.Id, x.Name }).
                    Where(x => x.IsActive));*/

            // but yet, this works

            /*var campaigns = Db.Dictionary<int, string>("select id, name from campaign where isactive = 1");*/




            return new HelloResponse { Result = "Hello, {0}!".Fmt(request.Name) };
        }
    }
}