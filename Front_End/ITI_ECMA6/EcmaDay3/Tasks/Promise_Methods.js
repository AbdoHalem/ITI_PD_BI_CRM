//? Example: Promise.all()
const p1 = new Promise((resolve) => {
    setTimeout(() => resolve("User Data Loaded"), 1000)
});

const p2 = new Promise((resolve) => {
    setTimeout(() => resolve("Posts Loaded"), 2000)
});
const p3 = new Promise((resolve, reject) => {
    setTimeout(() => reject("Network Error!"), 500)
}); //* This one fails

//& Scenario 1: All success
Promise.all([p1, p2])
    .then(results => {
        //* results is an array: ["User Data Loaded", "Posts Loaded"]
        console.log("All success:", results);
    })
    .catch(error => console.error(error));

//& Scenario 2: One failure (With p3)
Promise.all([p1, p2, p3])
    .then(results => console.log(results))
    .catch(error => {
        //* It fails immediately because p3 rejected
        console.error("Failed because of:", error); 
    });

//& Example: Promise.allSettled()
const task1 = Promise.resolve("File 1 Uploaded");
const task2 = Promise.reject("File 2 Failed (Size limit)");
const task3 = Promise.resolve("File 3 Uploaded");

Promise.allSettled([task1, task2, task3])
    .then(results => {
        //* results is an array of objects describing the outcome of each promise
        results.forEach((result, index) => {
            if (result.status === 'fulfilled') {
                console.log(`Task ${index + 1} Success: ${result.value}`);
            } else {
                console.log(`Task ${index + 1} Failed: ${result.reason}`);
            }
        });
    });

//& Example: Promise.any()
//^ Server A is down (Rejects fast)
const serverA = new Promise((_, reject) => setTimeout(() => reject("Server A Down"), 100));
//^ Server B is slow but works
const serverB = new Promise((resolve) => setTimeout(() => resolve("Image from Server B"), 500));
//^ Server C is slower
const serverC = new Promise((resolve) => setTimeout(() => resolve("Image from Server C"), 1000));

Promise.any([serverA, serverB, serverC])
    .then(firstSuccess => {
        //* It ignores Server A's error and takes Server B because it's the first SUCCESS
        console.log("First fulfilled task is:", firstSuccess); 
    })
    .catch(error => {
        //* This only runs if A, B, and C ALL fail
        console.log("All servers failed", error.errors);
    });


//& Example: Promise.race() for Timeout
const dataFetch = new Promise((resolve) => {
    //* Simulating a slow network request (3 seconds)
    setTimeout(() => resolve("Data received!"), 3000);
});

const timeout = new Promise((_, reject) => {
    //* Timeout limit (2 seconds)
    setTimeout(() => reject("Request timed out!"), 2000);
});

//^ Race the fetch against the timeout
Promise.race([dataFetch, timeout])
    .then(data => console.log(data))
    .catch(error => {
        //* This will run because the timeout (2s) is faster than the fetch (3s)
        console.error("Error:", error); 
    });