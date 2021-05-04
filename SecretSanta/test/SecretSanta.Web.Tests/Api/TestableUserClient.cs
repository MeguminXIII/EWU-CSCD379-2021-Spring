using SecretSanta.Web.Api;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SecretSanta.Web.Tests.Api
{
    public class TestableUserClient : IUsersClient
    {
        public List<DtoUser> DeleteAsyncDtoUserList {get; set;} = new();
        public int DeleteAsyncCalledCount{get; set;}
        public Task DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                DeleteAsyncCalledCount++;
                DeleteAsyncDtoUserList.RemoveAt(id);
            });
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAllUsers {get; set;} = new();
        public int GetAllAsyncCalledCount {get; set;}
        public Task<ICollection<User>> GetAllAsync()
        {
            GetAllAsyncCalledCount++;
            return Task.FromResult<ICollection<User>>(GetAllUsers);
        }

        public Task<ICollection<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public DtoUser? GetAsyncDtoUser {get; set;}
        public int GetAsyncCalledCount {get; set;}
        public Task<DtoUser> GetAsync(int id)
        {
            GetAsyncCalledCount++;
            if(!(GetAsyncDtoUser is null) && id == GetAsyncDtoUser.Id){
                return Task.FromResult<DtoUser>(GetAsyncDtoUser);
            }
            return null!;
        }

        public Task<DtoUser> GetAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public int PostAsyncCalledCount {get; set;}
        public List<DtoUser> PostAsyncParams {get;} = new();
        public Task<DtoUser> PostAsync(DtoUser myUser)
        {
            PostAsyncCalledCount++;
            PostAsyncParams.Add(myUser);
            var user = Task.FromResult(myUser);
            return user;
        }

        public Task<User> PostAsync(DtoUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public List<DtoUser> PutAsyncParams {get;} = new();
        public int PutAsyncCalledCounter {get; set;}
        public Task PutAsync(int id, DtoUser user)
        {
            PutAsyncCalledCounter++;
            PutAsyncParams[id] = user;
            return Task.FromResult(user);
        }

        public Task PutAsync(int id, DtoUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        Task<User> IUsersClient.PostAsync(DtoUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}