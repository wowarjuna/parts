Rx = {}

Rx.AsyncSubject = function(scheduler)
{
    /// <summary>Represents the result of an asynchronous operation. 1:(), 2:(scheduler)</summary>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
}

Rx.BehaviorSubject = function(value, scheduler)
{
    /// <summary>Represents an object that is both an observable sequence as well as an observer. 1:(value), 2:(value, scheduler)</summary>
    /// <param type='Object' name='value'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
}

Rx.BooleanDisposable = function()
{
    /// <summary>Represents an IDisposable that can be checked for status. 1:()</summary>

}

Rx.CompositeDisposable = function(d1, d2, d3, d4)
{
    /// <summary>Represents a group of Disposables that are disposed together. 1:(), 2:(d1), 3:(d1, d2), 4:(d1, d2, d3), 5:(d1, d2, d3, d4)</summary>
    /// <param type='IDisposable' name='d1'></param>
    /// <param type='IDisposable' name='d2'></param>
    /// <param type='IDisposable' name='d3'></param>
    /// <param type='IDisposable' name='d4'></param>
}

Rx.ConnectableObservable = function(source, subject)
{
    /// <summary>Represents an observable that can be connected and disconnected from its source. 1:(source), 2:(source, subject)</summary>
    /// <param type='Rx.Observable' name='source'></param>
    /// <param type='Rx.ISubject' name='subject'></param>
}

Rx.GroupedObservable = function()
{
    /// <summary>Represents an observable sequence of values that have a common key. 1:()</summary>

}

Rx.List = function(comparer)
{
    /// <summary>Represents mutable List semantics in JavaScript 1:(), 2:(comparer)</summary>
    /// <param type='FuncObjectObjectBoolean' name='comparer'></param>
}

Rx.MutableDisposable = function()
{
    /// <summary>Represents a disposable whose underlying disposable can be swapped for another disposable. 1:()</summary>

}

Rx.Notification = function(kind, value)
{
    /// <summary>Represents a notification to an observer. 1:(kind), 2:(kind, value)</summary>
    /// <param type='String' name='kind'></param>
    /// <param type='Object' name='value'></param>
}

Rx.Observable = function()
{
    /// <summary>Represents a push-style collection. 1:()</summary>

}

Rx.Observer = function(onNext, onError, onCompleted)
{
    /// <summary>Supports push-style iteration over an observable sequence. 1:(onNext), 2:(onNext, onError), 3:(onNext, onError, onCompleted)</summary>
    /// <param type='ActionObject' name='onNext'></param>
    /// <param type='ActionObject' name='onError'></param>
    /// <param type='Action' name='onCompleted'></param>
}

Rx.Pattern = function()
{
    /// <summary>Represents a join pattern. 1:()</summary>

}

Rx.Plan = function()
{
    /// <summary>Represents an execution plan for join patterns. 1:()</summary>

}

Rx.RefCountDisposable = function()
{
    /// <summary>Represents a disposable that only disposes its underlying disposable when all dependent disposables have been disposed. 1:()</summary>

}

Rx.ReplaySubject = function(bufferSize, window, scheduler)
{
    /// <summary>Represents an object that is both an observable sequence as well as an observer. 1:(bufferSize, window), 2:(bufferSize, window, scheduler)</summary>
    /// <param type='Number' name='bufferSize'></param>
    /// <param type='Number' name='window'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
}

Rx.Scheduler = function(schedule, scheduleWithTime)
{
    /// <summary>Represents an object that schedules units of work. 1:(schedule, scheduleWithTime)</summary>
    /// <param type='Action' name='schedule'></param>
    /// <param type='ActionInt32' name='scheduleWithTime'></param>
}

Rx.Subject = function(scheduler)
{
    /// <summary>Represents an object that is both an observable sequence as well as an observer. 1:(), 2:(scheduler)</summary>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
}
Rx.AsyncSubject.prototype = new Rx.Observable;
Rx.BehaviorSubject.prototype = new Rx.ReplaySubject;
Rx.ConnectableObservable.prototype = new Rx.Observable;
Rx.GroupedObservable.prototype = new Rx.Observable;
Rx.Notification.prototype = new Rx.Observable;
Rx.ReplaySubject.prototype = new Rx.Observable;
Rx.Subject.prototype = new Rx.Observable;
Rx.Disposable = {}

Rx.AsyncSubject.prototype.OnCompleted = function()
{
    /// <summary>Notifies all subscribed observers of the end of the sequence. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.AsyncSubject.prototype.OnError = function(exception)
{
    /// <summary>Notifies all subscribed observers with the exception. 1:(exception)</summary>
    /// <param type='Object' name='exception'></param>
    /// <returns type='Void'></returns>
}

Rx.AsyncSubject.prototype.OnNext = function(value)
{
    /// <summary>Notifies all subscribed observers with the value. 1:(value)</summary>
    /// <param type='Object' name='value'></param>
    /// <returns type='Void'></returns>
}


Rx.BooleanDisposable.prototype.Dispose = function()
{
    /// <summary>Sets the status to Disposed. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.BooleanDisposable.prototype.GetIsDisposed = function()
{
    /// <summary>Gets a value indicating whether the object is disposed. 1:()</summary>

    /// <returns type='Boolean'></returns>
}

Rx.CompositeDisposable.prototype.Add = function(item)
{
    /// <summary>Adds a disposable to the CompositeDisposable or disposes the disposable if the CompositeDisposable is disposed. 1:(item)</summary>
    /// <param type='IDisposable' name='item'></param>
    /// <returns type='Void'></returns>
}

Rx.CompositeDisposable.prototype.Clear = function()
{
    /// <summary>Removes and disposes all disposables from the CompositeDisposable, but does not dispose the CompositeDisposable. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.CompositeDisposable.prototype.Dispose = function()
{
    /// <summary>Disposes all disposables in the group and removes them from the group. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.CompositeDisposable.prototype.GetCount = function()
{
    /// <summary>Gets the number of disposables contained in the CompositeDisposable. 1:()</summary>

    /// <returns type='Number'></returns>
}

Rx.CompositeDisposable.prototype.Remove = function(item)
{
    /// <summary>Removes and disposes the first occurrence of a disposable from the CompositeDisposable. 1:(item)</summary>
    /// <param type='IDisposable' name='item'></param>
    /// <returns type='Boolean'></returns>
}

Rx.ConnectableObservable.prototype.Connect = function()
{
    /// <summary>Connects the observable to its source. 1:()</summary>

    /// <returns type='IDisposable'></returns>
}

Rx.ConnectableObservable.prototype.RefCount = function()
{
    /// <summary>Returns an observable sequence that stays connected to the source as long as there is at least one subscription to the observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Disposable.Create = function(action)
{
    /// <summary>Creates the disposable that invokes dispose when disposed. 1:(action)</summary>
    /// <param type='Action' name='action'></param>
    /// <returns type='IDisposable'></returns>
}


Rx.List.prototype.Add = function(item)
{
    /// <summary>Adds item to the list. 1:(item)</summary>
    /// <param type='Object' name='item'></param>
    /// <returns type='Void'></returns>
}

Rx.List.prototype.Clear = function()
{
    /// <summary>Clears the list. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.List.prototype.GetCount = function()
{
    /// <summary>Returns the amount of items in the list. 1:()</summary>

    /// <returns type='Number'></returns>
}

Rx.List.prototype.GetItem = function(index)
{
    /// <summary>returns item at position index. 1:(index)</summary>
    /// <param type='Number' name='index'></param>
    /// <returns type='Object'></returns>
}

Rx.List.prototype.IndexOf = function(item)
{
    /// <summary>Searches item in the list and returns it index if found, returns -1 otherwise. 1:(item)</summary>
    /// <param type='Object' name='item'></param>
    /// <returns type='Number'></returns>
}

Rx.List.prototype.Remove = function(item)
{
    /// <summary>Tries to remove item from list, returns boolean indicating success. 1:(item)</summary>
    /// <param type='Object' name='item'></param>
    /// <returns type='Boolean'></returns>
}

Rx.List.prototype.RemoveAt = function(index)
{
    /// <summary>Removes item at index. 1:(index)</summary>
    /// <param type='Number' name='index'></param>
    /// <returns type='Void'></returns>
}

Rx.List.prototype.SetItem = function(index, item)
{
    /// <summary>Replaces value at postition index with item. 1:(index, item)</summary>
    /// <param type='Number' name='index'></param>
    /// <param type='Object' name='item'></param>
    /// <returns type='Void'></returns>
}

Rx.List.prototype.ToArray = function()
{
    /// <summary></summary>

    /// <returns type='Object[]'></returns>
}

Rx.MutableDisposable.prototype.Dispose = function()
{
    /// <summary>Disposes the underlying disposable as well as all future replacements. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.MutableDisposable.prototype.Get = function()
{
    /// <summary>Gets a value indicating whether the MutableDisposable has an underlying disposable. 1:()</summary>

    /// <returns type='IDisposable'></returns>
}

Rx.MutableDisposable.prototype.Replace = function(disposable)
{
    /// <summary>Swaps and disposes the current disposable with the new disposable. 1:(disposable)</summary>
    /// <param type='IDisposable' name='disposable'></param>
    /// <returns type='Void'></returns>
}

Rx.Notification.prototype.Accept = function(observer)
{
    /// <summary>Invokes the observer's method corresponding to the notification. 1:(observer)</summary>
    /// <param type='Rx.Observer' name='observer'></param>
    /// <returns type='IDisposable'></returns>
}

Rx.Observable.prototype.Aggregate = function(seed, accumulator)
{
    /// <summary>Applies an accumulator function over an observable sequence. The specified seed value is used as the initial accumulator value. 1:(seed, accumulator)</summary>
    /// <param type='Object' name='seed'></param>
    /// <param type='FuncObjectObjectObject' name='accumulator'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Aggregate1 = function(accumulator)
{
    /// <summary>Applies an accumulator function over an observable sequence. 1:(accumulator)</summary>
    /// <param type='FuncObjectObjectObject' name='accumulator'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.All = function(predicate)
{
    /// <summary>Determines whether all elements of an observable sequence satisfy a condition. 1:(predicate)</summary>
    /// <param type='FuncObjectBoolean' name='predicate'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Amb = function(o1, o2, o3, o4)
{
    /// <summary>Returns the observable sequence that reacts first. 1:(o1), 2:(o1, o2), 3:(o1, o2, o3), 4:(o1, o2, o3, o4)</summary>
    /// <param type='Rx.Observable' name='o1'></param>
    /// <param type='Rx.Observable' name='o2'></param>
    /// <param type='Rx.Observable' name='o3'></param>
    /// <param type='Rx.Observable' name='o4'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.And = function(other)
{
    /// <summary>Matches when both observable sequences have an available value. 1:(other)</summary>
    /// <param type='Rx.Observable' name='other'></param>
    /// <returns type='Rx.Pattern'></returns>
}

Rx.Observable.prototype.Any = function(predicate)
{
    /// <summary>Determines whether any element of an observable sequence satisfies a condition. 1:(), 2:(predicate)</summary>
    /// <param type='FuncObjectBoolean' name='predicate'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.AsObservable = function()
{
    /// <summary>Hides the identity of an observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Average = function()
{
    /// <summary>Computes the average of a sequence of numeric values. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.BufferWithCount = function(count, skip)
{
    /// <summary>Projects each value of an observable sequence into a buffer. 1:(count), 2:(count, skip)</summary>
    /// <param type='Number' name='count'></param>
    /// <param type='Number' name='skip'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.BufferWithTime = function(timeSpan, timeShift, scheduler)
{
    /// <summary>Projects each value of an observable sequence into a buffer. 1:(timeSpan), 2:(timeSpan, timeShift), 3:(timeSpan, timeShift, scheduler)</summary>
    /// <param type='Number' name='timeSpan'></param>
    /// <param type='Number' name='timeShift'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.BufferWithTimeOrCount = function(timeSpan, count, scheduler)
{
    /// <summary>Projects each value of an observable sequence into a buffer. 1:(timeSpan, count), 2:(timeSpan, count, scheduler)</summary>
    /// <param type='Number' name='timeSpan'></param>
    /// <param type='Number' name='count'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Case = function(selector, sources, defaultSource, scheduler)
{
    /// <summary>Uses selector to determine which source in sources to use, uses defaultSource if no match is found. 1:(selector, sources), 2:(selector, sources, defaultSource), 3:(selector, sources, defaultSource, scheduler)</summary>
    /// <param type='FuncObservable' name='selector'></param>
    /// <param type='Dictionary' name='sources'></param>
    /// <param type='Rx.Observable' name='defaultSource'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Catch = function(o1, o2, o3, o4)
{
    /// <summary>Continues an observable sequence that is terminated by an exception with the next observable sequence. 1:(o1), 2:(o1, o2), 3:(o1, o2, o3), 4:(o1, o2, o3, o4), 5:(items), 6:(items, scheduler)</summary>
    /// <param type='Rx.Observable' name='o1'></param>
    /// <param type='Rx.Observable' name='o2'></param>
    /// <param type='Rx.Observable' name='o3'></param>
    /// <param type='Rx.Observable' name='o4'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.CombineLatest = function(right, selector)
{
    /// <summary>Merges two observable sequences into one observable sequence by using the selector function whenever one of the observable sequences has a new value. 1:(right, selector)</summary>
    /// <param type='Rx.Observable' name='right'></param>
    /// <param type='FuncObjectObjectObject' name='selector'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Concat = function(o1, o2, o3, o4)
{
    /// <summary>Concatenates all the observable sequences. 1:(o1), 2:(o1, o2), 3:(o1, o2, o3), 4:(o1, o2, o3, o4), 5:(items), 6:(items, scheduler)</summary>
    /// <param type='Rx.Observable' name='o1'></param>
    /// <param type='Rx.Observable' name='o2'></param>
    /// <param type='Rx.Observable' name='o3'></param>
    /// <param type='Rx.Observable' name='o4'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Contains = function(value, comparer)
{
    /// <summary>Determines whether an observable sequence contains a specified element by using the specified comparer. 1:(value), 2:(value, comparer)</summary>
    /// <param type='Object' name='value'></param>
    /// <param type='FuncObjectObjectBoolean' name='comparer'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Count = function()
{
    /// <summary>Returns an number representing the total number of elements in an observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Create = function(subcribe)
{
    /// <summary>Creates an observable sequence from the subscribe implementation. 1:(subcribe)</summary>
    /// <param type='FuncObserverAction' name='subcribe'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.CreateWithDisposable = function(subcribe)
{
    /// <summary>Creates an observable sequence from the subscribe implementation. 1:(subcribe)</summary>
    /// <param type='FuncObserverIDisposable' name='subcribe'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Defer = function(observableFactory)
{
    /// <summary>Returns an observable sequence that invokes the observableFactory function whenever a new observer subscribes. 1:(observableFactory)</summary>
    /// <param type='FuncObservable' name='observableFactory'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Delay = function(dueTime, scheduler)
{
    /// <summary>Time shifts the observable sequence by dueTime. The relative time intervals between the values are preserved. 1:(dueTime), 2:(dueTime, scheduler)</summary>
    /// <param type='Number' name='dueTime'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Dematerialize = function()
{
    /// <summary>Dematerializes the explicit notification values of an observable sequence as implicit notifications. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.DistinctUntilChanged = function(keySelector, comparer)
{
    /// <summary>Returns an observable sequence that contains only distinct contiguous values according to the keySelector and comparer. 1:(), 2:(keySelector), 3:(keySelector, comparer)</summary>
    /// <param type='FuncObjectObject' name='keySelector'></param>
    /// <param type='FuncObjectObjectBoolean' name='comparer'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Do = function(onNext, onError, onCompleted)
{
    /// <summary>Invokes the action for its side-effects on each value in the observable sequence. 1:(onNext), 2:(onNext, onError), 3:(onNext, onError, onCompleted), 4:(observer)</summary>
    /// <param type='ActionObject' name='onNext'></param>
    /// <param type='ActionObject' name='onError'></param>
    /// <param type='Action' name='onCompleted'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.DoWhile = function(source, condition)
{
    /// <summary>Repeats source as long as condition holds. 1:(source, condition)</summary>
    /// <param type='Rx.Observable' name='source'></param>
    /// <param type='FuncBoolean' name='condition'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Empty = function(scheduler)
{
    /// <summary>Returns an empty observable sequence. 1:(), 2:(scheduler)</summary>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Final = function()
{
    /// <summary>Returns an observable that contains only the final OnNext value. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Finally = function(finallyAction)
{
    /// <summary>Invokes finallyAction after source observable sequence terminates normally or by an exception. 1:(finallyAction)</summary>
    /// <param type='Action' name='finallyAction'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.For = function(source, resultSelector)
{
    /// <summary>Concatenates the observable sequences obtained by running the resultSelector for each element in source. 1:(source, resultSelector)</summary>
    /// <param type='Array' name='source'></param>
    /// <param type='FuncObjectObservable' name='resultSelector'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.ForkJoin = function(o1, o2, o3, o4, o5)
{
    /// <summary>Runs all observable sequences in parallel and combines their last values. 1:(o1, o2), 2:(o1, o2, o3), 3:(o1, o2, o3, o4), 4:(o1, o2, o3, o4, o5)</summary>
    /// <param type='Rx.Observable' name='o1'></param>
    /// <param type='Rx.Observable' name='o2'></param>
    /// <param type='Rx.Observable' name='o3'></param>
    /// <param type='Rx.Observable' name='o4'></param>
    /// <param type='Rx.Observable' name='o5'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.FromArray = function(items, scheduler)
{
    /// <summary>Returns an observable sequence that contains all values from the array in order. 1:(items), 2:(items, scheduler)</summary>
    /// <param type='Object[]' name='items'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.FromDOMEvent = function(window, eventName)
{
    /// <summary>Returns an observable sequence that contains the values of the underlying DOM event. 1:(element, eventName), 2:(document, eventName), 3:(window, eventName)</summary>
    /// <param type='WindowInstance' name='window'></param>
    /// <param type='String' name='eventName'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.FromHtmlEvent = function(window, eventName)
{
    /// <summary>Returns an observable sequence that contains the values of the underlying Html event. 1:(element, eventName), 2:(document, eventName), 3:(window, eventName)</summary>
    /// <param type='WindowInstance' name='window'></param>
    /// <param type='String' name='eventName'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.FromIEEvent = function(window, eventName)
{
    /// <summary>Returns an observable sequence that contains the values of the underlying Internet Explorer event. 1:(element, eventName), 2:(document, eventName), 3:(window, eventName)</summary>
    /// <param type='WindowInstance' name='window'></param>
    /// <param type='String' name='eventName'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Generate = function(initialState, condition, iterate, resultSelector, scheduler)
{
    /// <summary>Generates an observable sequence by iterating a state from an initial state until the condition fails. 1:(initialState, condition, iterate, resultSelector), 2:(initialState, condition, iterate, resultSelector, scheduler)</summary>
    /// <param type='FuncObject' name='initialState'></param>
    /// <param type='FuncObjectBoolean' name='condition'></param>
    /// <param type='FuncObjectObject' name='iterate'></param>
    /// <param type='FuncObjectObject' name='resultSelector'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.GenerateWithTime = function(initialState, condition, iterate, resultSelector, timeSelector, scheduler)
{
    /// <summary>Generates an observable sequence by iterating a state from an initial state until the condition fails. 1:(initialState, condition, iterate, resultSelector, timeSelector), 2:(initialState, condition, iterate, resultSelector, timeSelector, scheduler)</summary>
    /// <param type='FuncObject' name='initialState'></param>
    /// <param type='FuncObjectBoolean' name='condition'></param>
    /// <param type='FuncObjectObject' name='iterate'></param>
    /// <param type='FuncObjectObject' name='resultSelector'></param>
    /// <param type='FuncObjectInt32' name='timeSelector'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.GroupBy = function(keySelector, elementSelector, keySerializer)
{
    /// <summary>Groups the elements of an observable sequence according to a specified key selector function and keySerializer and selects the resulting elements by using a specified function. 1:(keySelector), 2:(keySelector, elementSelector), 3:(keySelector, elementSelector, keySerializer)</summary>
    /// <param type='FuncObjectObject' name='keySelector'></param>
    /// <param type='FuncObjectObject' name='elementSelector'></param>
    /// <param type='FuncObjectString' name='keySerializer'></param>
    /// <returns type='Rx.GroupedObservable'></returns>
}

Rx.Observable.If = function(condition, thenSource, elseSource)
{
    /// <summary>If condition is true, then thenSource else elseSource. 1:(condition, thenSource, elseSource)</summary>
    /// <param type='FuncBoolean' name='condition'></param>
    /// <param type='Rx.Observable' name='thenSource'></param>
    /// <param type='Rx.Observable' name='elseSource'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Interval = function(period, scheduler)
{
    /// <summary>Returns an observable sequence that produces a value after each period. 1:(period), 2:(period, scheduler)</summary>
    /// <param type='Number' name='period'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.IsEmpty = function()
{
    /// <summary>Determines whether an observable sequence is empty. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Join = function(p1, p2, p3, p4, p5, p6, p7, p8)
{
    /// <summary>Joins together the results from several plans. 1:(p1), 2:(p1, p2), 3:(p1, p2, p3), 4:(p1, p2, p3, p4), 5:(p1, p2, p3, p4, p5), 6:(p1, p2, p3, p4, p5, p6), 7:(p1, p2, p3, p4, p5, p6, p7), 8:(p1, p2, p3, p4, p5, p6, p7, p8)</summary>
    /// <param type='Rx.Plan' name='p1'></param>
    /// <param type='Rx.Plan' name='p2'></param>
    /// <param type='Rx.Plan' name='p3'></param>
    /// <param type='Rx.Plan' name='p4'></param>
    /// <param type='Rx.Plan' name='p5'></param>
    /// <param type='Rx.Plan' name='p6'></param>
    /// <param type='Rx.Plan' name='p7'></param>
    /// <param type='Rx.Plan' name='p8'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Let = function(source, resultSelector)
{
    /// <summary>Returns an observable sequence that invokes selector with value whenever a new observer subscribes. 1:(func), 2:(func, subjectFactory), 3:(source, resultSelector)</summary>
    /// <param type='Object' name='source'></param>
    /// <param type='FuncObjectObservable' name='resultSelector'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Materialize = function()
{
    /// <summary>Materializes the implicit notifications of an observable sequence as explicit notification values. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Max = function()
{
    /// <summary>Returns the maximum value in an observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.MaxBy = function(keySelector, comparer)
{
    /// <summary>Returns the elements in an observable sequence with the maximum key value by using the specified comparer. 1:(keySelector), 2:(keySelector, comparer)</summary>
    /// <param type='FuncObjectObject' name='keySelector'></param>
    /// <param type='FuncObjectObjectInt32' name='comparer'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Merge = function(o1, o2, o3, o4)
{
    /// <summary>Merges all the observable sequences into a single observable sequence. 1:(o1), 2:(o1, o2), 3:(o1, o2, o3), 4:(o1, o2, o3, o4), 5:(items), 6:(items, scheduler)</summary>
    /// <param type='Rx.Observable' name='o1'></param>
    /// <param type='Rx.Observable' name='o2'></param>
    /// <param type='Rx.Observable' name='o3'></param>
    /// <param type='Rx.Observable' name='o4'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.MergeObservable = function()
{
    /// <summary>Merges an observable sequence of observable sequences into an observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Min = function()
{
    /// <summary>Returns the minimum value in an observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.MinBy = function(keySelector, comparer)
{
    /// <summary>Returns the elements in an observable sequence with the minimum key value by using the specified comparer. 1:(keySelector), 2:(keySelector, comparer)</summary>
    /// <param type='FuncObjectObject' name='keySelector'></param>
    /// <param type='FuncObjectObjectInt32' name='comparer'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Never = function()
{
    /// <summary>Returns a non-terminating observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.OnErrorResumeNext = function(o1, o2, o3, o4)
{
    /// <summary>Continues an observable sequence that is terminated normally or by an exception with the next observable sequence. 1:(o1), 2:(o1, o2), 3:(o1, o2, o3), 4:(o1, o2, o3, o4), 5:(items), 6:(items, scheduler)</summary>
    /// <param type='Rx.Observable' name='o1'></param>
    /// <param type='Rx.Observable' name='o2'></param>
    /// <param type='Rx.Observable' name='o3'></param>
    /// <param type='Rx.Observable' name='o4'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Prune = function(selector, scheduler)
{
    /// <summary>Returns a connectable observable sequence that shares a single subscription to the underlying source containing only the last notification. 1:(), 2:(selector), 3:(selector, scheduler)</summary>
    /// <param type='FuncObservableObservable' name='selector'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Publish = function(selector)
{
    /// <summary>Returns an observable sequence that is the result of invoking the selector on a connectable observable sequence that shares a single subscription to the underlying source. 1:(), 2:(selector)</summary>
    /// <param type='FuncObservableObservable' name='selector'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Range = function(start, count, scheduler)
{
    /// <summary>Generates an observable sequence of integral numbers within a specified range. 1:(start, count), 2:(start, count, scheduler)</summary>
    /// <param type='Number' name='start'></param>
    /// <param type='Number' name='count'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.RemoveInterval = function()
{
    /// <summary>Removes the timestamp from each value of an observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.RemoveTimestamp = function()
{
    /// <summary>Removes the timestamp from each value of an observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Repeat = function(value, count, scheduler)
{
    /// <summary>Generates an observable sequence that contains one repeated value. 1:(), 2:(count), 3:(count, scheduler), 4:(value), 5:(value, count), 6:(value, count, scheduler)</summary>
    /// <param type='Object' name='value'></param>
    /// <param type='Number' name='count'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Replay = function(selector, bufferSize, window, scheduler)
{
    /// <summary>Returns a connectable observable sequence that shares a single subscription to the underlying source replaying bufferSize notifications within window. 1:(), 2:(selector), 3:(selector, bufferSize), 4:(selector, bufferSize, window), 5:(selector, bufferSize, window, scheduler)</summary>
    /// <param type='FuncObservableObservable' name='selector'></param>
    /// <param type='Number' name='bufferSize'></param>
    /// <param type='Number' name='window'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Retry = function(count, scheduler)
{
    /// <summary>Repeats the source observable sequence the retryCount times or until it successfully terminates. 1:(), 2:(count), 3:(count, scheduler)</summary>
    /// <param type='Number' name='count'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Return = function(value, scheduler)
{
    /// <summary>Returns an observable sequence that contains a single value. 1:(value), 2:(value, scheduler)</summary>
    /// <param type='Object' name='value'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Sample = function(interval, scheduler)
{
    /// <summary>Samples the observable sequence at each interval. 1:(interval), 2:(interval, scheduler)</summary>
    /// <param type='Number' name='interval'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Scan = function(seed, accumulator)
{
    /// <summary>Applies an accumulator function over an observable sequence and returns each intermediate result. The specified seed value is used as the initial accumulator value. 1:(seed, accumulator)</summary>
    /// <param type='Object' name='seed'></param>
    /// <param type='FuncObjectObjectObject' name='accumulator'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Scan0 = function(seed, accumulator)
{
    /// <summary>Applies an accumulator function over an observable sequence and returns each intermediate result. The specified seed value is prepended to the sequence once a message comes in. 1:(seed, accumulator)</summary>
    /// <param type='Object' name='seed'></param>
    /// <param type='FuncObjectObjectObject' name='accumulator'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Scan1 = function(accumulator)
{
    /// <summary>Applies an accumulator function over an observable sequence and returns each intermediate result. 1:(accumulator)</summary>
    /// <param type='FuncObjectObjectObject' name='accumulator'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Select = function(selector)
{
    /// <summary>Projects each value of an observable sequence into a new form by incorporating the element's index. 1:(selector), 2:(selector)</summary>
    /// <param type='FuncObjectInt32Object' name='selector'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.SelectMany = function(selector)
{
    /// <summary>Projects each value of an observable sequence to an observable sequence and flattens the resulting observable sequences into one observable sequence. 1:(selector)</summary>
    /// <param type='FuncObjectObservable' name='selector'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Skip = function(count)
{
    /// <summary>Bypasses a specified number of values in an observable sequence and then returns the remaining values. 1:(count)</summary>
    /// <param type='Number' name='count'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.SkipLast = function(count)
{
    /// <summary>Bypasses a specified number of values at the end of an observable sequence. 1:(count)</summary>
    /// <param type='Number' name='count'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.SkipUntil = function(other)
{
    /// <summary>Returns the values from the source observable sequence only after the other observable sequence produces a value. 1:(other)</summary>
    /// <param type='Rx.Observable' name='other'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.SkipWhile = function(predicate)
{
    /// <summary>Bypasses values in an observable sequence as long as a specified condition is true and then returns the remaining values. 1:(predicate)</summary>
    /// <param type='FuncObjectBoolean' name='predicate'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Start = function(original, instance, arguments, scheduler)
{
    /// <summary>Invokes the function asynchronously, using scheduler to schedule the work. 1:(original), 2:(original), 3:(original), 4:(original), 5:(original), 6:(original, instance), 7:(original, instance), 8:(original, instance), 9:(original, instance), 10:(original, instance), 11:(original, instance, arguments), 12:(original, instance, arguments), 13:(original, instance, arguments), 14:(original, instance, arguments), 15:(original, instance, arguments), 16:(original, scheduler), 17:(original, scheduler), 18:(original, scheduler), 19:(original, scheduler), 20:(original, scheduler), 21:(original, instance, scheduler), 22:(original, instance, scheduler), 23:(original, instance, scheduler), 24:(original, instance, scheduler), 25:(original, instance, scheduler), 26:(original, instance, arguments, scheduler), 27:(original, instance, arguments, scheduler), 28:(original, instance, arguments, scheduler), 29:(original, instance, arguments, scheduler), 30:(original, instance, arguments, scheduler)</summary>
    /// <param type='FuncObjectArrayObject' name='original'></param>
    /// <param type='Object' name='instance'></param>
    /// <param type='Object[]' name='arguments'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.StartWith = function(values, scheduler)
{
    /// <summary>Prepends a sequence values to an observable sequence. 1:(value), 2:(value, scheduler), 3:(values), 4:(values, scheduler)</summary>
    /// <param type='Object[]' name='values'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Subscribe = function(onNext, onError, onCompleted)
{
    /// <summary>Subscribes an observer to the observable sequence. 1:(), 2:(observer), 3:(onNext), 4:(onNext, onError), 5:(onNext, onError, onCompleted)</summary>
    /// <param type='ActionObject' name='onNext'></param>
    /// <param type='ActionObject' name='onError'></param>
    /// <param type='Action' name='onCompleted'></param>
    /// <returns type='IDisposable'></returns>
}

Rx.Observable.prototype.Sum = function()
{
    /// <summary>Computes the sum of a sequence of numeric values. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Switch = function()
{
    /// <summary>Transforms an observable sequence of observable sequences into an observable sequence producing values only from the most recent observable sequence. 1:()</summary>

    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Take = function(count, scheduler)
{
    /// <summary>Returns a specified number of contiguous values from the start of an observable sequence. 1:(count), 2:(count, scheduler)</summary>
    /// <param type='Number' name='count'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.TakeLast = function(count)
{
    /// <summary>Returns a specified number of contiguous values from the end of an observable sequence. 1:(count)</summary>
    /// <param type='Number' name='count'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.TakeUntil = function(other)
{
    /// <summary>Returns the values from the source observable sequence until the other observable sequence produces a value. 1:(other)</summary>
    /// <param type='Rx.Observable' name='other'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.TakeWhile = function(predicate)
{
    /// <summary>Returns values from an observable sequence as long as a specified condition is true, and then skips the remaining values. 1:(predicate)</summary>
    /// <param type='FuncObjectBoolean' name='predicate'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Then = function(selector)
{
    /// <summary>Matches when the observable sequence has an available value and projects the value. 1:(selector)</summary>
    /// <param type='Function' name='selector'></param>
    /// <returns type='Rx.Plan'></returns>
}

Rx.Observable.prototype.Throttle = function(dueTime, scheduler)
{
    /// <summary>Ignores values from an observable sequence which are followed by another value before dueTime. 1:(dueTime), 2:(dueTime, scheduler)</summary>
    /// <param type='Number' name='dueTime'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Throw = function(exception, scheduler)
{
    /// <summary>Returns an observable sequence that terminates with an exception. 1:(exception), 2:(exception, scheduler)</summary>
    /// <param type='Object' name='exception'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.TimeInterval = function(scheduler)
{
    /// <summary>Records the time interval for each value of an observable sequence according to the scheduler's notion of time. 1:(), 2:(scheduler)</summary>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Timeout = function(dueTime, other, scheduler)
{
    /// <summary>Returns the source observable sequence until completed or if dueTime elapses replaces the observable sequence with other. 1:(dueTime), 2:(dueTime, scheduler), 3:(dueTime, other), 4:(dueTime, other, scheduler)</summary>
    /// <param type='Number' name='dueTime'></param>
    /// <param type='Rx.Observable' name='other'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.Timer = function(dueTime, period, scheduler)
{
    /// <summary>Returns an observable sequence that produces a value after dueTime has elapsed and then after each period. 1:(dueTime), 2:(dueTime, period), 3:(dueTime, period, scheduler)</summary>
    /// <param type='Number' name='dueTime'></param>
    /// <param type='Number' name='period'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Timestamp = function(scheduler)
{
    /// <summary>Records the timestamp for each value of an observable sequence according to the scheduler's notion of time. 1:(), 2:(scheduler)</summary>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.ToAsync = function(original, scheduler)
{
    /// <summary>Converts the function into an asynchronous function, using scheduler to schedule the work. 1:(original), 2:(original), 3:(original), 4:(original), 5:(original), 6:(original, scheduler), 7:(original, scheduler), 8:(original, scheduler), 9:(original, scheduler), 10:(original, scheduler)</summary>
    /// <param type='FuncObjectArrayObject' name='original'></param>
    /// <param type='Rx.Scheduler' name='scheduler'></param>
    /// <returns type='FuncObjectArrayObservable'></returns>
}

Rx.Observable.Using = function(resourceSelector, resourceUsage)
{
    /// <summary>Retrieves resource from resourceSelector for use in resourceUsage and disposes the resource once the resulting observable sequence terminates. 1:(resourceSelector, resourceUsage)</summary>
    /// <param type='FuncIDisposable' name='resourceSelector'></param>
    /// <param type='FuncIDisposableObservable' name='resourceUsage'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Where = function(selector)
{
    /// <summary>Filters the values of an observable sequence based on a predicate by incorporating the element's index. 1:(selector), 2:(selector)</summary>
    /// <param type='FuncObjectInt32Boolean' name='selector'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.While = function(condition, source)
{
    /// <summary>Repeats source as long as condition holds. 1:(condition, source)</summary>
    /// <param type='FuncBoolean' name='condition'></param>
    /// <param type='Rx.Observable' name='source'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.XmlHttpRequest = function(url)
{
    /// <summary>Starts an asynchronous XmlHttpRequest. 1:(details), 2:(url)</summary>
    /// <param type='String' name='url'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observable.prototype.Zip = function(right, selector)
{
    /// <summary>Merges two observable sequences into one observable sequence by using the selector function. 1:(right, selector)</summary>
    /// <param type='Rx.Observable' name='right'></param>
    /// <param type='FuncObjectObjectObject' name='selector'></param>
    /// <returns type='Rx.Observable'></returns>
}

Rx.Observer.prototype.AsObserver = function()
{
    /// <summary>Hides the identity of an observer. 1:()</summary>

    /// <returns type='Rx.Observer'></returns>
}

Rx.Observer.Create = function(onNext, onError, onCompleted)
{
    /// <summary>Creates an observer from the specified OnNext, OnError, and OnCompleted actions. 1:(onNext), 2:(onNext, onError), 3:(onNext, onError, onCompleted)</summary>
    /// <param type='ActionObject' name='onNext'></param>
    /// <param type='ActionObject' name='onError'></param>
    /// <param type='Action' name='onCompleted'></param>
    /// <returns type='Rx.Observer'></returns>
}

Rx.Observer.prototype.OnCompleted = function()
{
    /// <summary>Notifies the observer of the end of the sequence. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.Observer.prototype.OnError = function(value)
{
    /// <summary>Notifies the observer that an exception has occurred. 1:(value)</summary>
    /// <param type='Object' name='value'></param>
    /// <returns type='Void'></returns>
}

Rx.Observer.prototype.OnNext = function(value)
{
    /// <summary>Notifies the observer of a new value in the sequence. 1:(value)</summary>
    /// <param type='Object' name='value'></param>
    /// <returns type='Void'></returns>
}

Rx.Pattern.prototype.And = function(other)
{
    /// <summary>Matches when all observable sequences have an available value. 1:(other)</summary>
    /// <param type='Rx.Observable' name='other'></param>
    /// <returns type='Rx.Pattern'></returns>
}

Rx.Pattern.prototype.Then = function(selector)
{
    /// <summary>Matches when all observable sequences have an available value and projects the values. 1:(selector)</summary>
    /// <param type='Function' name='selector'></param>
    /// <returns type='Rx.Plan'></returns>
}


Rx.RefCountDisposable.prototype.Dispose = function()
{
    /// <summary>Disposes the underlying disposable only when all dependent disposables have been disposed. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.RefCountDisposable.prototype.GetDisposable = function()
{
    /// <summary></summary>

    /// <returns type='IDisposable'></returns>
}

Rx.ReplaySubject.prototype.OnCompleted = function()
{
    /// <summary>Notifies the observer of the end of the sequence. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.ReplaySubject.prototype.OnError = function(exception)
{
    /// <summary>Notifies the observer that an exception has occurred. 1:(exception)</summary>
    /// <param type='Object' name='exception'></param>
    /// <returns type='Void'></returns>
}

Rx.ReplaySubject.prototype.OnNext = function(value)
{
    /// <summary>Notifies the observer of a new value in the sequence. 1:(value)</summary>
    /// <param type='Object' name='value'></param>
    /// <returns type='Void'></returns>
}

Rx.Scheduler.prototype.Now = function()
{
    /// <summary>Gets the scheduler's notion of current time. 1:()</summary>

    /// <returns type='Number'></returns>
}

Rx.Scheduler.Schedule = function(action)
{
    /// <summary>Schedules action to be executed. 1:(action)</summary>
    /// <param type='Action' name='action'></param>
    /// <returns type='IDisposable'></returns>
}

Rx.Scheduler.ScheduleRecursive = function(action)
{
    /// <summary>Schedules action to be executed recursively. 1:(action)</summary>
    /// <param type='ActionAction' name='action'></param>
    /// <returns type='IDisposable'></returns>
}

Rx.Scheduler.ScheduleRecursiveWithTime = function(action, dueTime)
{
    /// <summary>Schedules action to be executed recursively after each dueTime. 1:(action, dueTime)</summary>
    /// <param type='ActionActionInt32' name='action'></param>
    /// <param type='Number' name='dueTime'></param>
    /// <returns type='IDisposable'></returns>
}

Rx.Scheduler.ScheduleWithTime = function(action, dueTime)
{
    /// <summary>Schedules action to be executed after dueTime. 1:(action, dueTime)</summary>
    /// <param type='Action' name='action'></param>
    /// <param type='Number' name='dueTime'></param>
    /// <returns type='IDisposable'></returns>
}

Rx.Subject.prototype.OnCompleted = function()
{
    /// <summary>Notifies all subscribed observers of the end of the sequence. 1:()</summary>

    /// <returns type='Void'></returns>
}

Rx.Subject.prototype.OnError = function(exception)
{
    /// <summary>Notifies all subscribed observers with the exception. 1:(exception)</summary>
    /// <param type='Object' name='exception'></param>
    /// <returns type='Void'></returns>
}

Rx.Subject.prototype.OnNext = function(value)
{
    /// <summary>Notifies all subscribed observers with the value. 1:(value)</summary>
    /// <param type='Object' name='value'></param>
    /// <returns type='Void'></returns>
}
Rx.Disposable.Empty = null;
Rx.GroupedObservable.prototype.Key = null;
Rx.Notification.prototype.Kind = null;
Rx.Notification.prototype.Value = null;
Rx.Scheduler.CurrentThread = null;
Rx.Scheduler.Immediate = null;
Rx.Scheduler.Timeout = null;