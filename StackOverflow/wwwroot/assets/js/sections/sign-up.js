let errorIcon = document.querySelector(
  ".wrapper__content__flex__form-container__form__flex-item--error"
);
let successIcon = document.querySelector(
  ".wrapper__content__flex__form-container__form__flex-item--success"
);

let form = document.querySelector(
  ".wrapper__content__flex__form-container__form"
);

let displayName = document.getElementById("display-name");
let email = document.getElementById("email");
let password = document.getElementById("pw");

form.addEventListener("submit", (e) => {
  //e.preventDefault();

  checkInputs();
});

function checkInputs() {
  let nameValue = displayName.value.trim();
  let emailValue = email.value.trim();
  let passwordValue = password.value;

  if (nameValue === "") {
    setErrorFor(displayName, "Display name cannot be blank");
  } else {
    setSuccessFor(displayName);
  }

  if (emailValue === "") {
    setErrorFor(email, "Email  cannot be blank");
  } else if (!isEmail(emailValue)) {
    setErrorFor(email, "Email  is not valid");
  } else {
    setSuccessFor(email);
  }

  if (passwordValue === "") {
    setErrorFor(password, "Password  cannot be blank");
  } else if (passwordValue.length < 8) {
    setErrorFor(password, "Password  cannot be less than 8 character");
  } else {
    setSuccessFor(password);
  }
}
function setErrorFor(input, message) {
  let formControl = input.parentElement.parentElement;
  let p = formControl.querySelector("p#p");
  let icon = formControl.querySelector(
    ".wrapper__content__flex__form-container__form__flex-item--error"
  );
  let success = formControl.querySelector(
    ".wrapper__content__flex__form-container__form__flex-item--success"
  );

  icon.style.display = "block";
  success.style.display = "none";
  p.innerHTML = message;
  input.className = "error";
}

function setSuccessFor(input) {
  let formControl = input.parentElement.parentElement;
  let p = formControl.querySelector("p#p");
  p.innerHTML = "";
  let err = formControl.querySelector(
    ".wrapper__content__flex__form-container__form__flex-item--error"
  );
  let icon = formControl.querySelector(
    ".wrapper__content__flex__form-container__form__flex-item--success"
  );

  icon.style.display = "block";
  err.style.display = "none";

  input.className = "success";
}

function isEmail(email) {
  // return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)!(".+"))@((\[[0-9]{1-3}\.[0-9]{1-3}\.[0-9]{1-3}\.[0-9]{1-3}])!(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/.test(
  //   email
  // );
  return /^[^]+@[^]+\.[a-zA-Z]{2,3}$/.test(email);
}
