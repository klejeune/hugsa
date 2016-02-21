using Hugsa.Core.Engine.Words.Attributes;

namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    class ParticipePasseVerb  : IWordCategory {
        public string Text { get; set; }
        public string VerbId { get; set; }
        public Gender Gender { get; set; }
        public Number Number { get; set; }

        public ParticipePasseVerb(string text, string verbId, Gender gender, Number number) {
            this.Text = text;
            this.VerbId = verbId;
            this.Gender = gender;
            this.Number = number;
        }

        public WordCategoryType Type {
            get { return WordCategoryType.Verb; }
        }
    }
}
