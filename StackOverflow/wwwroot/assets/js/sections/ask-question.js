let check = document.querySelector(
  ".ask-question__container__main__left__confirm__input >input"
);

let form = document.querySelector(".ask-question__container__main__left__form");

check.addEventListener("click", () => {
  if (check.checked) {
    //console.log("hello");
    form.style.opacity = 1;
    form.style.pointerEvents = "fill";
  } else {
    form.style.opacity = 0.3;
    form.style.pointerEvents = "none";
  }
});

// toggle

let elements = document.querySelectorAll(
  ".ask-question__container__main__right__into--sidebarwidget__main__ul__li__button > div:last-child"
);

let ArrowsUp = document.querySelectorAll(
  ".ask-question__container__main__right__into--sidebarwidget__main__ul__li__button > div:last-child .arrow-up"
);
let ArrowsDown = document.querySelectorAll(
  ".ask-question__container__main__right__into--sidebarwidget__main__ul__li__button > div:last-child .arrow-down"
);

let toggledElements = document.querySelectorAll(
  ".ask-question__container__main__right__into--sidebarwidget__main__ul__li__desc"
);

let lis = document.querySelectorAll(
  ".ask-question__container__main__right__into--sidebarwidget__main__ul__li"
);

elements.forEach((element) => {
  element.addEventListener("click", () => {
    ArrowsDown.forEach((down) => {
      toggledElements.forEach((t) => {
        t.classList.add("display-block");
        toggledElements.forEach((t) => {
          t.classList.toggle("display-none");
        });
      });
      down.classList.toggle("display-none");
    });
    ArrowsUp.forEach((Up) => {
      Up.classList.toggle("display-none");
      toggledElements.forEach((t) => {
        t.classList.remove("display-block");
      });
    });
  });
});

// button

let headers = document.querySelectorAll(
  ".ask-question__container__main__right__into--sidebarwidget__header > button"
);

let othersitesToggle = document.querySelector(
  ".ask-question__container__main__right__into--sidebarwidget__other-sites"
);

let moreLinks = document.querySelector(
  ".ask-question__container__main__right__into--sidebarwidget__more-links"
);

headers.forEach((head) => {
  head.addEventListener("click", () => {
    othersitesToggle.classList.toggle("display-none");
  });
  head.addEventListener("click", () => {
    moreLinks.classList.toggle("display-none");
  });
});
