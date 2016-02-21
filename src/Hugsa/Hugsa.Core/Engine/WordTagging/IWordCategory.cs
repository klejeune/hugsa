namespace Hugsa.Core.Engine.WordTagging {
    public interface IWordCategory {
        string Text { get; }
        WordCategoryType Type { get; }
    }
}
