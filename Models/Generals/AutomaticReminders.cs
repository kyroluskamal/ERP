using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Generals
{
    public class AutomaticReminders
    {
        public int Id { get; set; }
        [ForeignKey(nameof(EmailTemplateId))]
        public EmailsTemplates EmailsTemplates { get; set; }
        public int EmailTemplateId { get; set; }
        [ForeignKey(nameof(WhenOptionId))]
        public WhenRemidersSent WhenRemidersSent { get; set; }
        public int WhenOptionId { get; set; }
    }
}
