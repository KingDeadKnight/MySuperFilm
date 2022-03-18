namespace MySuperFilm.ViewModels.Api
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TestEditorViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}