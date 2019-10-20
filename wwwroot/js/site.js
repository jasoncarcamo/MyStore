const endpoint = '/Login';


document.getElementById("clockin-button").addEventListener("click", (e) => {
    e.preventDefault();

    fetch(endpoint, {
        method:"POST",
        headers: {
            'content-type': "application/json"
        },
        body: JSON.stringify({ Name: document.getElementById("employee-name").value, Password: document.getElementById("employee-password").value })
    })
        .then(res => {

            if (!res.ok) {
                return res.json().then(e => Promise.reject(e))
            };

            return res.json();
        })
        .then(data => console.log(data))
        .catch(error => console.log(error));
})
