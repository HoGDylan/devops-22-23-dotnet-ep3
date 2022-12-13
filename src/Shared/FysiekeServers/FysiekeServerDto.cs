﻿using FluentValidation;

namespace Shared.FysiekeServers
{
    public static class FysiekeServerDto
    {
        public class Index
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String ServerAddress { get; set; }
            public int Memory { get; set; }
            public int Storage { get; set; }
            public int Amount_vCPU { get; set; }
            public int MemoryAvailable { get; set; }
            public int StorageAvailable { get; set; }
            public int VCPUsAvailable { get; set; }
        }

        public class Detail : Index
        {

        }

        public class Mutate
        {
            public String Name { get; set; }
            public String ServerAddress { get; set; }
            public int Memory { get; set; }
            public int Storage { get; set; }
            public int Amount_vCPU { get; set; }
            public int MemoryAvailable { get; set; }
            public int StorageAvailable { get; set; }
            public int VCPUsAvailable { get; set; }

            /*public class Validator : AbstractValidator<Mutate>
            {
                public Validator()
                {
                    RuleFor(x => x.Name).NotEmpty().Length(1, 250);
                    RuleFor(x => x.Price).InclusiveBetween(1, 250);
                    RuleFor(x => x.Category).NotEmpty().Length(1, 250);
                    RuleFor(x => x.ImageAmount).GreaterThanOrEqualTo(1);
                }
            }*/
        }
    }
}