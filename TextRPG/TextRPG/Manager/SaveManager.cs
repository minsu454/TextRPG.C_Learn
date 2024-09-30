using Newtonsoft.Json;

namespace TextRPG
{
    public class SaveManager
    {
        private string path = "../../../../Save/Monster.json";

        /// <summary>
        /// save해주는 함수
        /// </summary>
        public void Save<T>(T t) where T : class
        {
            string serialize = JsonConvert.SerializeObject(t);
            File.WriteAllText(path, serialize);
        }

        /// <summary>
        /// 데이터 로드해주는 함수
        /// </summary>
        public T? Load<T>() where T : class
        {
            if (!CanLoadFile())
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path))!;
        }

        /// <summary>
        /// 파일을 열 수 있는지 알려주는 함수
        /// </summary>
        public bool CanLoadFile()
        {
            if (File.Exists(path))
            {
                return true;
            }

            return false;
        }
    }

}
