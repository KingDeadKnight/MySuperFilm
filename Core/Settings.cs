namespace MySuperFilm.Core
{
    using System.Collections.Generic;

    public class Settings
    {
        public string DefaultLanguage { get; set; }

        public IEnumerable<string> AvailableLanguages { get; set; }
    }
}