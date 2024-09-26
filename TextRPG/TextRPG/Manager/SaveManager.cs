using Newtonsoft.Json;

namespace TextRPG
{
    public class SaveManager
    {
        private string path = "../../../../Save/Player.json";

        /// <summary>
        /// save해주는 함수
        /// </summary>
        public void Save<T>(T t) where T : class
        {
            string serialize = JsonConvert.SerializeObject(t);
            File.WriteAllText(path, serialize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Load<T>() where T : class, new()
        {
            if (!File.Exists(path))
            {
                return new T();
            }

            return JsonConvert.DeserializeObject<T>(path)!;
        }
    }

}
