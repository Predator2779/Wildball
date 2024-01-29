using System;

namespace EditorExtension
{
    [AttributeUsage(AttributeTargets.Method)]
    public class EditorButton : Attribute
    {
        public string Name;

        public EditorButton(string name)
        {
            Name = name;
        }
    }
}
