const HelpQuestion = document.getElementById("help-icon");
const BurgerLogOut = document.getElementById("burger-icon");

const HelpToggle = document.querySelector(".help-questions");
const LogOutToggle = document.querySelector(".log-out");

HelpQuestion.addEventListener("click", (e) => {
  e.preventDefault();
  HelpToggle.classList.toggle("display-none");
});
BurgerLogOut.addEventListener("click", (e) => {
  e.preventDefault();
  LogOutToggle.classList.toggle("display-none");
});

const sectionButtons = document.querySelectorAll(
  ".container__main-content__all__center__navigation > a"
);

sectionButtons.forEach((btn) => {
  btn.addEventListener("click", (e) => {
    e.preventDefault();
    sectionButtons.forEach((b) => {
      b.classList.remove("is-selected");
    });

    btn.classList.add("is-selected");
  });
});

// nav left

const activityLinks = document.querySelectorAll(
  ".container__main-content__all__activity-main__nav__ul--li > a"
);

activityLinks.forEach((link) => {
  link.addEventListener("click", (e) => {
    e.preventDefault();
    activityLinks.forEach((l) => {
      l.classList.remove("is-selected");
    });
    link.classList.add("is-selected");
  });
});

// switch
let inp = document.getElementById("inp");
let switchToggle = document.querySelector(
  ".container__main-content__all__settings-main__content__interface__section__body__switch--indicator"
);
let leftBar = document.querySelector(".container__left-sidebar");
let mainContent = document.querySelector(".container__main-content");

inp.addEventListener("click", () => {
  setTimeout(() => {
    switchToggle.classList.toggle("indicator");
    leftBar.classList.toggle("display-none");
    mainContent.style.border = "none";
  }, 300);

  let result = localStorage.setItem("test", inp.value);
});

// calendar
// const calendar = document.querySelector(
//   ".container__main-content__all__header__left__flex-item__user-activity__item__flex__button"
// );

// const calendarPopOver = document.querySelector(
//   ".container__main-content__all__header__left__flex-item__user-activity__item__flex__popover"
// );
// calendar.addEventListener("click", () => {
//   calendarPopOver.classList.toggle("display-none");
// });

// theme

let themes = document.querySelectorAll(
  ".container__main-content__all__settings-main__content__interface__section__themes__list__theme"
);

let leftbar = document.querySelector(
  ".container__main-content__all__settings-main__nav"
);
let header = document.getElementById("head");

let radios = document.getElementsByName("color");

let h1 = document.getElementById("for-theme");

let body = document.querySelector(".container__main-content");
body.classList.add(localStorage.getItem("color"));
header.classList.add(localStorage.getItem("head"));
leftbar.classList.add(localStorage.getItem("head"));
h1.classList.add(localStorage.getItem("h1"));
let val = localStorage.getItem("checked");

themes.forEach((theme) => {
  theme.addEventListener("click", () => {
    for (let i = 0; i < radios.length; i++) {
      if (theme.id === "theme-first") {
        body.classList.remove("os");
        body.classList.remove("black");
        body.classList.add("white");
        localStorage.setItem("color", "white");
        leftbar.classList.remove("c-white");
        header.classList.remove("c-white");
        h1.classList.remove("c-white");
      }
      if (theme.id === "theme-second") {
        if (
          window.matchMedia &&
          window.matchMedia("(prefers-color-scheme: dark)").matches
        ) {
          body.classList.remove("white");
          body.classList.remove("black");
          body.classList.add("black");
          localStorage.setItem("color", "black");
          leftbar.classList.add("c-white");
          header.classList.add("c-white");
          localStorage.setItem("head", "c-white");
          h1.classList.add("c-white");
          localStorage.setItem("h1", "c-white");
        } else {
          body.classList.remove("white");
          body.classList.remove("black");
          body.classList.add("white");
          localStorage.setItem("color", "white");
          leftbar.classList.remove("c-white");
          header.classList.remove("c-white");
          h1.classList.remove("c-white");
        }
      }
      if (theme.id === "theme-third") {
        body.classList.remove("white");
        body.classList.remove("os");
        body.classList.add("black");
        localStorage.setItem("color", "black");
        leftbar.classList.add("c-white");
        header.classList.add("c-white");
        localStorage.setItem("head", "c-white");
        h1.classList.add("c-white");
        localStorage.setItem("h1", "c-white");
      }
    }
  });
});
