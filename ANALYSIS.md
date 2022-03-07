There are several ways for thread synchronization. 
Blocking threads and making them wait for something. Thread.Sleep, thread.Join etc
Limit the number threads to enter the critical sections. 
Exclusive locks: only one thread enters(Lock, monitor) and Non-exclusive(Semaphore, Mutex etc) locks are limited threads to enter the section.

I am using the locking mechanism which is most commonly used to ensure the one thread can enter the critical section.
I have created a static object at service level then lock that specific object while executing the update process. 

I have also created the exception handling middleware to handle the exception in application. 
