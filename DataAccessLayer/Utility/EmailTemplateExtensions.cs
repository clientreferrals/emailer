using DataAccessLayer.DataBase;

namespace DataAccessLayer.Utility
{
    public static class EmailTemplateExtensions
    {
        public static string CustomToString(this EmailTemplate emailTemplate)
        {
            return emailTemplate.TemplateName;
        }

    }
}
