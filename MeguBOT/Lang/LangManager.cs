namespace MeguBOT.Lang
{
    using System.Collections;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Threading;

    public class LangManager
    {
        public LangManager(string resourceName, Assembly assembly)
        {
            this.ResourceManager = new ResourceManager(resourceName, assembly);
        }

        private ResourceManager ResourceManager { get; set; }

        public string GetResourceName(string value)
        {
            DictionaryEntry entry = this.ResourceManager.GetResourceSet(Thread.CurrentThread.CurrentCulture, true, true).OfType<DictionaryEntry>().FirstOrDefault(dictionaryEntry => dictionaryEntry.Value.ToString() == value);
            return entry.Key.ToString();
        }

        public string GetResourceValue(string name)
        {
            string value = this.ResourceManager.GetString(name);
            return !string.IsNullOrEmpty(value) ? value : null;
        }
    }
}
