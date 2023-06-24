using Core.Interface;

namespace Core.Abstract
{
  public abstract class AObjectModel : IObjectModel
  {
    public virtual void Create() { }
    public virtual void Initialize() { }
    public virtual void Start() { }
  }
}
