//? Lab3.js
//& Function to fetch country data from REST Countries API
async function countriesAPI(country_name) {
    let response = await fetch(`https://restcountries.com/v2/name/${country_name}`);
    let data = await response.json();
    return data[0];
}

//* Get data of Country 1
let country1 = countriesAPI("USA");
country1.then((data) => {
    console.log(data);
    //* Update the country card with its data
    updateCard(data, 1);
    //* Check if borders exist before fetching
    if(!data.borders) {
        throw new Error("No neighbors found");
    }
    //* Get data of neighbor country
    return countriesAPI(data.borders[0]);
    })
    .then((neighborData) => {
        //^ This .then() handles the result of the SECOND fetch
        console.log(neighborData);
        //* Update the neighbour country card with its data
        updateCard(neighborData, 2);
    })
    .catch((error) => {
        //^ This .catch() handles errors from BOTH fetches
        console.error("Error fetching country data:", error);
});

//& Helper function to update the HTML card with data
function updateCard(data, i){
    document.getElementById(`flag${i}`).src = data.flag;
    document.getElementById(`card${i}_title`).innerText = data.name;
    document.getElementById(`card${i}_subtitle`).innerText = data.region;
    document.getElementById(`info${i}`).innerText = `${data.population} People \n ${data.languages[0].name } \n ${data.currencies[0].name}`;
}
