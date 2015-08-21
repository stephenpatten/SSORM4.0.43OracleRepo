using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace WebApplication5.ServiceModel.Models
{
    public interface IAudit
    {
        long CreatedDate { get; set; }
        long ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }

    public class Campaign : IHasId<int>, IAudit
    {
        [Required]
        public string CampaignPhone { get; set; }

        public decimal CostAmount { get; set; }
        public long EndDate { get; set; }
        public decimal FixedCost { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefaultCampaign { get; set; }
        public bool IsDuplicate { get; set; }
        public bool IsEmail { get; set; }
        public bool IsExceptionCampaign { get; set; }
        public bool IsFactorTrustApp { get; set; }
        public bool IsFactorTrustLeads { get; set; }
        public bool IsFirmOffer { get; set; }
        public bool IsRetread { get; set; }

        [Required]
        public int LeadDelCostTypeId { get; set; }

        [Required]
        public int LeadDelRespTypeId { get; set; }

        [Required]
        public int LeadDelTypeId { get; set; }

        [Required]
        public int LeadProviderId { get; set; }

        [Required]
        public int LeadRoutingTypeId { get; set; }

        [Required]
        public int MasterId { get; set; }

        [Required]
        public string Name { get; set; }

        public string NoteAgent { get; set; }
        public string NoteMisc { get; set; }
        public int PhoneTriggerId { get; set; }
        public long StartDate { get; set; }

        [Required]
        public int TrackingId { get; set; }

        public long CreatedDate { get; set; }
        public long ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        [AutoIncrement]
        public int Id { get; set; }
    }
}