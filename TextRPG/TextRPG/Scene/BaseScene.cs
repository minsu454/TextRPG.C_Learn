using Newtonsoft.Json.Linq;

namespace TextRPG
{
    public abstract class BaseScene
    {
        public virtual void Init() { }
        public abstract void Load();
    }
}
