using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.CourseManagement.Data
{
    public class DataSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (!context.Course.AnyAsync().Result)
            {
                var courses = new List<Course>
                {
                    new Course { Name = "DotNet Core Fundamentals", Description ="In this course, you will learn how to build a RESTful API with ASP.NET Core, which is quite different from a regular web API. You will get there by learning about major topics like how you can correctly interact with your API by using the correct HTTP methods & status codes, method safety and idempotency, validation, common features like paging, sorting, filtering and data shaping, and supporting HATEOAS, versioning, caching and concurrency. By the end of this course, you will be able to build an API with level 3 maturity, which is the highest possible level for APIs. Before you begin, make sure you are already familiar with C# and know a thing or two about building APIs with ASP.NET Core." , PreRequisites = ".NET Framework, C#", Level=1},
                    new Course { Name = "Machine Learning", Description ="Have you ever wondered what machine learning is? That’s what this course is designed to teach you. You’ll explore the open source programming language R, learn about training and testing a model as well as using a model. By the time you’re done, you’ll have a clear understanding of exactly what machine learning is all about" , PreRequisites = "NIL", Level=1},
                };

                var faculties = new List<Faculty>
                {
                    new Faculty { Name = "Andy Wicks",Department =".NET" },
                    new Faculty { Name = "Nidhi Sharma", Department ="AI/Machine Learning" }
                };

                var courseList = new List<CourseList>
                {
                    new CourseList { Schedule = DateTime.Parse("06/29/2018 9:00"), Location = "Floor 2 B Wing", Course=courses[0], Faculty= faculties[0] },
                    new CourseList { Schedule = DateTime.Parse("06/11/2018 14:00"), Location = "Floor 1 A Wing",  Course=courses[1], Faculty= faculties[1] },
                };

                context.AddRange(courses);
                context.AddRange(faculties);
                context.AddRange(courseList);

                context.SaveChanges();
            }
        }
    }
}
