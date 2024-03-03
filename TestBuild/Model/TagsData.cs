namespace TestBuild.Model
{
    public class RecordTags
    {
        public Dictionary<string, int> TagRecords { get; set; }
    }

    public class TagRecord
    {
        public string Tag { get; set; }
        public int Count { get; set; }
    }


}