let ChangeImage = document.getElementById("changePhoto");
let ImagePopup = document.querySelector(".picture-popup__into");

ChangeImage.addEventListener("click", (e) => {
  e.preventDefault();
  ImagePopup.classList.toggle("display-none");
});

const calendarPopover = document.querySelector(
  ".container__main-content__all__header__left__flex-item__user-activity__item__flex__popover"
);
const Calendar = document.querySelector(
  ".container__main-content__all__header__left__flex-item__user-activity__item__flex__button"
);

Calendar.addEventListener("click", () => {
  calendarPopover.classList.toggle("display-none");
});
