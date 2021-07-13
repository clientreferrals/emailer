namespace Models.DTO
{
    public class ViewTemplateDto
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public override string ToString()
        {
            return this.TemplateName;
        }
    }
}
