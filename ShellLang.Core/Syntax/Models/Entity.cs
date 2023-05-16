using ShellLang.Core.Syntax.Enums;

namespace ShellLang.Core.Syntax.Models
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
