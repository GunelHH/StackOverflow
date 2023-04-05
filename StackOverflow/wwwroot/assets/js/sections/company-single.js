const fadeP = document.querySelector(".fade-p");

const fadeButtons = document.querySelectorAll(
  ".container__company__all__header__body__content__buttons__flex__item"
);

const nav = document.querySelector(".container__company__all__header__nav");

const header = document.querySelector(".main-head");

const headerImg = document.querySelector(
  ".container__company__all__header__body__image > img"
);
const buttonsOnScroll = document.querySelector(
  ".container__company__all__header__body__sticky"
);

document.addEventListener("scroll", () => {
  if (window.scrollY > 50) {
    fadeP.classList.add("fade-out");
    nav.classList.add("nav-scroll");
    header.style.fontSize = "21px";
    headerImg.style.width = "32px";
    headerImg.style.height = "32px";
    headerImg.style.borderRadius = "5px";

    fadeButtons.forEach((btn) => {
      btn.classList.add("fade-out");
      setTimeout(() => {
        fadeP.classList.add("display-none");
        btn.classList.add("display-none");
      }, 100);
    });
    buttonsOnScroll.style.display = "block";
  } else {
    fadeP.classList.remove("fade-out");
    nav.classList.remove("nav-scroll");
    header.style.fontSize = "43px";
    headerImg.style.width = "96px";
    headerImg.style.height = "96px";
    headerImg.style.borderRadius = "10px";
    buttonsOnScroll.style.display = "none";

    fadeButtons.forEach((btn) => {
      btn.classList.remove("fade-out");
      setTimeout(() => {
        fadeP.classList.remove("display-none");
        btn.classList.remove("display-none");
      }, 100);
    });
  }
});

const btns = document.getElementById("btn-popover");
const btnPopOvers = document.querySelectorAll(
  ".container__company__all__header__body__content__buttons__flex__item__popover"
);

const smButton = document.querySelector(
  ".container__company__all__header__buttons"
);
const smBtnPopOver = document.getElementById("sm-btn");

const stickPopOver = document.getElementById("stick-btn");

const mainBtn = document.querySelector(
  ".container__company__all__header__body__content__buttons"
);
const mainBtnPopOver = document.getElementById("main-btn");

smButton.addEventListener("click", () => {
  smBtnPopOver.classList.toggle("display-none");
});

buttonsOnScroll.addEventListener("click", () => {
  stickPopOver.classList.toggle("display-none");
});

mainBtn.addEventListener("click", () => {
  mainBtnPopOver.classList.toggle("display-none");
});

// show hide

const locations = document.querySelectorAll(
  ".container__company__all__body__right__location__article__flex__item"
);
const lbtn = document.querySelector(
  ".container__company__all__body__right__location__button"
);
const locationsMoreBtn = document.querySelector(
  ".container__company__all__body__right__location__button > button"
);

if (locations.length > 5) {
  for (let i = 5; i <= locations.length - 1; i++) {
    locations[i].classList.add("display-none");
  }
}

locationsMoreBtn.addEventListener("click", () => {
  locations.forEach((l) => {
    l.classList.remove("display-none");
  });
  lbtn.style.display = "none";
});
