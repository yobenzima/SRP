using Hanssens.Net;

using SRP.Web.Contracts;

namespace SRP.Web.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly LocalStorage mLocalStorage;

        public LocalStorageService()
        {
            var tConfig = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "SRP.STORE"
            };
            mLocalStorage = new LocalStorage(tConfig);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach(var tKey in keys)
                mLocalStorage.Remove(tKey);
        }

        public bool Exists(string key)
        {
            return mLocalStorage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            if(mLocalStorage.Exists(key))
                return mLocalStorage.Get<T>(key);

            return default!;
        }

        public void SetStorageValue<T>(string key, T value)
        {
            mLocalStorage.Store(key, value);
            mLocalStorage.Persist();
        }
    }
}
