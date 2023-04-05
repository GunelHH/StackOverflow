// nav

const burger = document.querySelector(".nav-burger");
const burgerToggle = document.querySelector(".nav-burger-toggle");
const main = document.querySelector("main");

const product = document.querySelector("#products");
const arrow = document.querySelector(".popover-arrow");
const productToggle = document.querySelector(".products-toggle");

const input = document.querySelector(".nav-search__input");
const arrowSearch = document.querySelector(".popover-arrow__search");
const inputFocus = document.querySelector(".nav-search__input-group");

const burgerFirst = document.getElementById("nav-first");
const burgerSecond = document.getElementById("nav-second");
const burgerThird = document.getElementById("nav-third");

burger.addEventListener("click", (e) => {
  e.preventDefault();
  if (burgerToggle.style.display === "block") {
    burgerToggle.style.display = "none";
    burgerFirst.classList.remove("burger-x");
    burgerSecond.style.display = "block";
    burgerThird.style.transform = "rotate(0deg)";
  } else {
    burgerToggle.style.display = "block";
    burgerFirst.classList.add("burger-x");
    burgerThird.style.transform = "rotate(-45deg)";
    burgerSecond.style.display = "none";
  }
});

product.addEventListener("click", (e) => {
  e.preventDefault();
  if (
    arrow.style.display === "block" &&
    productToggle.style.display === "block"
  ) {
    arrow.style.display = "none";
    productToggle.style.display = "none";
    console.log("if");
  } else {
    arrow.style.display = "block";
    productToggle.style.display = "block";
    console.log("else");
  }
});
