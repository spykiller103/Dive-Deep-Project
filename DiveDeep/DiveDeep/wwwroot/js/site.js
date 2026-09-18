const equipments = document.querySelectorAll(".equipment-item")
const searchInput = document.querySelector(".searchBar")
const searchResults = document.querySelector(".search-results")

searchInput.addEventListener("input", (e) => {
    const value = e.target.value.toLowerCase()

    searchResults.innerHTML = ""

    equipments.forEach((equipment) => {
        const title = equipment.querySelector(".equipment-title").textContent.toLowerCase()
        const category = equipment.querySelector(".equipment-category").textContent.toLowerCase()

        if (title.includes(value) || category.includes(value)) {
            equipment.style.display = ""

            if (value !== "") {
                const image = equipment.querySelector("img").src
                const equipmentTitle = equipment.querySelector(".equipment-title").textContent
                const equipmentCategory = equipment.querySelector(".equipment-category").textContent
                const link = equipment.querySelector("a").href

                searchResults.innerHTML += `
                    <a href="${link}" class="search-result">
                        <img src="${image}" alt="${equipmentTitle}">
                        <div>
                            <p>${equipmentTitle}</p>
                            <span>${equipmentCategory}</span>
                        </div>
                    </a>
                `
            }
        }
        else {
            equipment.style.display = "none"
        }
    })
})