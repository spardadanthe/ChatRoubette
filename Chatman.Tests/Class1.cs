using AutoMapper;
using Machine.Specifications;
using System;
using System.Collections.Generic;

namespace Chatman.Tests
{
    [Subject("Automapper")]
    public class When_mapping_entity_to_state
    {

        Establish context = () =>
        {
            entity = new UserModel("gosho");
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserTableProfile>();
            });
            mapper= config.CreateMapper();
        };

        Because of = () => dto = mapper.Map<UserTable>(entity);
         
        It should_be_the_same = () => dto.Id.ShouldEqual(entity.Id);

        It should_be_the_same_name = () => dto.Name.ShouldEqual(entity.Username);
        static IMapper mapper;

        static UserModel entity;

        static UserTable dto;

        public class UserTableProfile : Profile
        {
            public UserTableProfile()
            {
                CreateMap<UserModel, UserTable>().ForMember(dto => dto.Id, x => x.MapFrom(src => src.Id));
                CreateMap<UserModel, UserTable>().ForMember(dto => dto.Name, x => x.MapFrom(src => src.Username));
                CreateMap<UserTable, UserModel>().ForMember(dto => dto.Id, x => x.MapFrom(src => src.Id));
                CreateMap<UserTable, UserModel>().ForMember(dto => dto.Username, x => x.MapFrom(src => src.Name));
            }
        }
        public class UserModel {
            private  UserModel()
            {

            }
            public UserModel(string name)
            {
                this.Id = Guid.NewGuid();
                this.Username = name;
            }
            public Guid Id { get; set; }

            public string Username { get; set; }
        }
        public class UserTable
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
        }
    }

    [Subject("Automapper")]
    public class When_mapping_state_to_dto
    {

        Establish context = () =>
        {
            dto = new UserTable() {
                UserIds = new List<string>() { "pencho" }
            };
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserTableProfile>();
            });
            mapper = config.CreateMapper();
        };

        Because of = () => entity = mapper.Map<UserModel>(dto);

        It should_be_the_same = () => dto.Id.ShouldEqual(entity.Id);

        It should_be_the_same_name = () => dto.Name.ShouldEqual(entity.Username);
        static IMapper mapper;

        static UserModel entity;

        static UserTable dto;

        public class UserTableProfile : Profile
        {
            public UserTableProfile()
            {
                CreateMap<UserModel, UserTable>().ForMember(dto => dto.Id, x => x.MapFrom(src => src.Id));
                CreateMap<UserModel, UserTable>().ForMember(dto => dto.Name, x => x.MapFrom(src => src.Username));
                //CreateMap<UserModel, UserTable>().ForMember(dto => dto.UserIds, x => x.MapFrom(src => src.UserIds));
                CreateMap<UserTable, UserModel>().ForMember(dto => dto.Id, x => x.MapFrom(src => src.Id));
                CreateMap<UserTable, UserModel>().ForMember(dto => dto.Username, x => x.MapFrom(src => src.Name));
            }
        }
        public class UserModel
        {
            private UserModel(){ }

            public UserModel(string name)
            {
                this.Id = Guid.NewGuid();
                this.Username = name;
            }
            public Guid Id { get; private set; }

            public string Username { get; private set; }

            public List<string> UserIds { get; private set; }
        }
        public class UserTable
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public List<string> UserIds{ get; set; }
        }
    }
}
