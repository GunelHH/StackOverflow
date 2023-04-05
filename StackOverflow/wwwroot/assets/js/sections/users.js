const usersPhoto = document.querySelectorAll("#userr");
const userInfo = document.querySelector(".user-info");

usersPhoto.forEach((user) => {
  user.addEventListener("mouseover", () => {
    userInfo.style.opacity = 1;
    userInfo.style.visibility = "visible";
  });
  user.addEventListener("mouseleave", () => {
    userInfo.style.opacity = 0;
    userInfo.style.visibility = "hidden";
  });
});

// live search

const inputt = document.querySelector(
  ".container__main-content__all--filtering--filter > input"
);

const Users = document.querySelectorAll(
  ".container__main-content__users__all__user"
);
let NoResult = document.querySelector(".container__main-content__all__browser");

inputt.addEventListener("input", (e) => {
  let value = e.target.value.trim().toLowerCase();

  Users.forEach((user) => {
    let userName = user.firstElementChild.nextElementSibling.firstElementChild;

    let isVisible = userName.innerText.toLowerCase().trim().includes(value);
    user.classList.toggle("display-none", !isVisible);
    // if (!isVisible) {
    //   console.log("if");
    //   return (NoResult.style.display = "block");
    // } else {
    //   console.log("none");
    //   return (NoResult.style.display = "none");
    // }
  });
});
