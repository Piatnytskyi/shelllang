using ShellLang.Core.Enums;

namespace ShellLang.Core.Models
{
    public struct Entity
    {
        public object Value { set; get; }
        public readonly ObjectType Type { get; }

        public Entity(object value, ObjectType type)
        {
            Value = value;
            Type = type;
        }
    }
}
