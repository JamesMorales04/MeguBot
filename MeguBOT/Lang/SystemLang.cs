namespace MeguBOT.Lang
{
    using System.Collections;
    using System.Linq;
    using System.Resources;

    internal class SystemLang
    {
        private static SystemLang instance;

        private System.Globalization.CultureInfo currentSystemLang;

        private SystemLang()
        {
            this.currentSystemLang = new System.Globalization.CultureInfo("es");
            this.ResourceManager = new ResourceManager("MeguBOT.Lang.Lang", this.GetType().Assembly);
        }

        private ResourceManager ResourceManager { get; set; }

        public static SystemLang GetInstance()
        {
            if (instance == null)
            {
                instance = new SystemLang();
            }

            return instance;
        }

        public void ChangeLang(string lang)
        {
            this.currentSystemLang = new System.Globalization.CultureInfo(lang);
        }

        public string GetResourceName(string value)
        {
            DictionaryEntry entry = this.ResourceManager.GetResourceSet(this.currentSystemLang, true, true).OfType<DictionaryEntry>().FirstOrDefault(dictionaryEntry => dictionaryEntry.Value.ToString() == value);
            return entry.Key.ToString();
        }

        public string GetResourceValue(string name)
        {
            string value = this.ResourceManager.GetString(name, this.currentSystemLang);
            return !string.IsNullOrEmpty(value) ? value : null;
        }
    }
}