using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TagService.Core.Entities
{
    /// <summary>
    /// https://jasperfx.github.io/marten/documentation/documents/advanced/hierarchies/
    /// </summary>
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

     
        public Enums.TagType Type { get; set; } = Enums.TagType.IsActive;


        public bool IsActive
        {
            get
            {
                return Type.HasFlag(Enums.TagType.IsActive);
            }
            set
            {
                if (value == true)
                    Type = Type | Enums.TagType.IsActive;
                else
                    Type = Type & ~Enums.TagType.IsActive;
            }
        }


    }

    public class ChildTag : Tag
    {

    }

    public class SynonymTag : Tag
    {

    }
}
