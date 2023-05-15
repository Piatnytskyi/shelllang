using ShellLang.Core.Enums;

namespace ShellLang.Core.Models
{
    public struct Object
    {
        public object Value { set; get; }
        public readonly ObjectType Type { get; }

        public Object(object value, ObjectType type)
        {
            Value = value;
            Type = type;
        }
    }
}
