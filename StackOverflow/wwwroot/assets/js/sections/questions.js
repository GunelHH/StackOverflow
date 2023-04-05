const more = document.querySelector(".more-button");
const morePopover = document.querySelector(
  ".container__main-content__questions__about__flex__item__filter--popover"
);

more.addEventListener("click", () => {
  morePopover.classList.toggle("display-none");
});

// filter
const filter = document.getElementById("filter");
const filterButton = document.querySelector(".filter-button");

filterButton.addEventListener("click", () => {
  filter.classList.toggle("display-none");
});

// watch

let watchInput = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content__input"
);

const watchList = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content__tags-list"
);
const watchNoContent = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content__no-content"
);
const buttonX = document.querySelectorAll(".delete-tag");

const watchAddButton = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content__no-content > a"
);

let watched = document.querySelector(
  ".container__main-content__right-sidebar__watch"
);

let watchContent = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content"
);

let addButton = document.querySelector(
  ".container__main-content__right-sidebar__watch__watched__content__input > form > button"
);

watchAddButton.addEventListener("click", Appear);

let watchInputElement =
  watchInput.firstElementChild.firstChild.nextElementSibling;

function Appear() {
  watchNoContent.classList.add("display-none");
  watchInput.classList.remove("display-none");
  watchInputElement.focus();
}

addButton.addEventListener("click", (e) => {
  e.preventDefault();
  let value = watchInputElement.value;
  if (value !== "") {
    let div = document.createElement("div");
    div.classList.add(
      "container__main-content__right-sidebar__watch__watched__content__tags-list__tag"
    );
    let a = document.createElement("a");
    a.innerText = value;
    let span = document.createElement("span");
    span.classList.add("delete-tag");

    watchList.appendChild(div);
    div.appendChild(a);
    a.appendChild(span);
    console.log("oldu gulum");
    watchList.classList.remove("display-none");
  }
});

// ignored

let ignoredInput = document.querySelector(
  ".container__main-content__right-sidebar__watch__ignored__content__input"
);
let ignoredButton = document.querySelector(
  ".container__main-content__right-sidebar__watch__ignored__content--button"
);
let ignoredVisible = document.querySelector(
  ".container__main-content__right-sidebar__watch__ignored__content__visible"
);

ignoredButton.addEventListener("click", () => {
  ignoredButton.classList.add("display-none");
  ignoredInput.classList.remove("display-none");
  ignoredVisible.classList.remove("display-none");

  ignoredInput.firstElementChild.firstChild.nextElementSibling.focus();
});
