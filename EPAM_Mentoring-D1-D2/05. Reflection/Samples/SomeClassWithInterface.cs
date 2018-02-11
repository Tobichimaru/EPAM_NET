using IoCContainer;

namespace Samples
{
    [Export(typeof(ISomeInterface))]
    public class SomeClassWithInterface : ISomeInterface
    {
    }
}
