using Newtonsoft.Json;

namespace WebApplication2.Model
{
    public class QuestionModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("programTitle")]
        public string ProgramTitle { get; set; }

        [JsonProperty("programDescription")]
        public string ProgramDescription { get; set; }

        [JsonProperty("paragraphQuestion")]
        public string ParagraphQuestion { get; set; }

        [JsonProperty("dropdownQuestion")]
        public string DropdownQuestion { get; set; }

        [JsonProperty("yesnoQuestion")]
        public string YesNoQuestion { get; set; }

        [JsonProperty("multipleChoiceQuestion")]
        public string MultipleChoiceQuestion { get; set; }

        [JsonProperty("numericQuestion")]
        public string NumericQuestion { get; set; }

        [JsonProperty("dateQuestion")]
        public string DateQuestion { get; set; }
    }
}
