const quoteElement = document.querySelector(".card__quote");
const buttonElement = document.querySelector(".card__button");

document.addEventListener("DOMContentLoaded", async () => {
  try {
    const response = await fetch("http://localhost:5204/quote");
    const quote = await response.json();
    quoteElement.textContent = quote;
  } catch (error) {
    console.log(error);
  }
});

buttonElement.addEventListener("click", async () => {
  try {
    const response = await fetch("http://localhost:5204/quote");
    const quote = await response.json();
    quoteElement.textContent = quote;
  } catch (error) {
    console.log(error);
  }
});
