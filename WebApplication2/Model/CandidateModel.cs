
using Newtonsoft.Json;
namespace WebApplication2.Model
{
    public class CandidateModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("candidateId")]
        public string CandidateId { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public long Phone { get; set; } // Changed to long for phone number

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("currentresidence")]
        public string CurrentResidence { get; set; }

        [JsonProperty("IDnumber")]
        public string IDnumber { get; set; }

        [JsonProperty("DoB")]
        public DateTime DoB { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("paragraphanswer")]
        public string ParagraphAnswer { get; set; } // Changed property name to follow C# naming conventions

        [JsonProperty("dropdownanswer")]
        public string DropdownAnswer { get; set; }

        [JsonProperty("yesnoanswer")]
        public bool YesNoAnswer { get; set; } // Changed to bool for yes/no answer

        [JsonProperty("multiplechoiceanswer")]
        public string MultipleChoiceAnswer { get; set; }

        [JsonProperty("numericanswer")]
        public int NumericAnswer { get; set; } // Changed to int for numeric answer

        [JsonProperty("dateanswer")]
        public DateTime DateAnswer { get; set; }
    }
}
