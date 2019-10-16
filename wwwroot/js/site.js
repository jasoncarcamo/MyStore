const endpoint = 'api/Employees';


document.getElementById("submit-button").addEventListener("click", (e) => {
    e.preventDefault();

    fetch(endpoint, {
        mode: "no-cors",
        redirect: "follow",
        headers: {
            'content-type': "application/json"
        }
    })
        .then(res => res.json())
        .then(data => console.log(data))
        .catch(error => console.log(error));
})
