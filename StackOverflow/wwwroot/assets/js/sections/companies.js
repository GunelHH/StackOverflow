const filterButton = document.querySelector(
  ".container__main-content__content__search-form__inputs--filter"
);
const filterSection = document.querySelector(
  ".container__main-content__content__search-form__inputs--filter--popover"
);
const Cancel = document.getElementById("cancel");

// filterButton.addEventListener("click", () => {
//   //   if (filterSection.style.display == "block") {
//   //     filterSection.style.display = "none";
//   //   } else {
//   if ((filterSection.style.display = "none")) {
//     filterSection.style.display = "block";
//   }
// });

document.addEventListener("click", function (event) {
  if (
    event.target.closest(
      ".container__main-content__content__search-form__inputs--filter"
    )
  ) {
    filterSection.style.display = "block";
  } else {
    filterSection.style.display = "none";
  }
});

const reset = document.querySelector(
  ".container__main-content__content__search-form__inputs--search-companies__body > span"
);
const inputReset = document.querySelector(
  ".container__main-content__content__search-form__inputs--search-companies__body > input"
);

// reset.forEach((r) => {
//   r.addEventListener("click", function () {
//     inputReset.forEach((i) => {
//       console.log("hell");
//       i.innerHTML = "";
//     });
//   });
// });

reset.addEventListener("click", () => {
  console.log(inputReset.innerHTML);
});
