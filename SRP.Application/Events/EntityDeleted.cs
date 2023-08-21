using MediatR;

using SRP.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Events;

/// <summary>
/// An event that is raised when an entity is deleted.
/// </summary>
/// <typeparam name="T"></typeparam>
public class EntityDeleted<T> : INotification where T : ParentEntity
{
    public EntityDeleted(T entity)
    {
        Entity = entity;
    }

    public T Entity { get; private set; }
}

