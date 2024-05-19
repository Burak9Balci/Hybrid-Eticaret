using Newtonsoft.Json;

namespace Project.MVCUI.Models.SessionService
{
    public static class SessionExtention
    {
        public static void SetObject(this ISession session,string key,object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }

        public static T GetObject<T>(this ISession session,string key) where T : class
        {
            string obje = session.GetString(key);
            if (obje != null)
            {
                T last = JsonConvert.DeserializeObject<T>(obje);
                return last;
            }
            return null;
        }
        
    }
}
