const inputTag = document.querySelector(
  ".container__main-content__all--filtering--filter > input"
);
const tags = document.querySelectorAll(
  ".container__main-content__all__tags__list__item"
);

inputTag.addEventListener("input", (e) => {
  let value = e.target.value.trim().toLowerCase();

  tags.forEach((tag) => {
    let tagName = tag.firstElementChild.firstElementChild.firstElementChild;

    let isVisible = tagName.innerText.toLowerCase().trim().includes(value);
    tag.classList.toggle("display-none", !isVisible);
    // if (!isVisible) {
    //   console.log("if");
    //   return (NoResult.style.display = "block");
    // } else {
    //   console.log("none");
    //   return (NoResult.style.display = "none");
    // }
  });
});
