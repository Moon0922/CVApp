<template>
  <v-app-bar>

      <v-col cols="2">
        <a href="/"><img class="avatar" src="/assets/logo.png" alt="logo"/></a>
      </v-col>
      <v-col cols="8">
        <ul class="navbar-nav">
          <li class="nav-item dropdown">
            <a href="javascript:void(0)" class="dropbtn">Products</a>
            <div class="dropdown-content">
              <v-container>
                <v-row>
                  <v-col cols="6">
                    <ul class="sub-col">
                      <a href="#">LPR</a>
                      <li class="sub-col-item"><a href="/product/license-plate-recognition?country=german">German</a></li>
                      <li class="sub-col-item"><a href="/product/license-plate-recognition?country=german">Ukraine</a></li>
                      <li class="sub-col-item"><a href="/product/license-plate-recognition?country=german">China</a></li>
                    </ul>
                  </v-col>
                  <v-col cols="6">
                    <ul class="sub-col">
                      <a href="#">Facial Recognition</a>
                      <li class="sub-col-item"><a>Face Detection</a></li>
                      <li class="sub-col-item"><a>Face Landmark</a></li>
                    </ul>
                  </v-col>
                </v-row>
              </v-container>
            </div>
          </li>
          <li><a href="/about-us">About Us</a></li>
        </ul>
      </v-col>
      <v-col cols="2"></v-col>
  </v-app-bar>
</template>
<style scoped lang="scss">

img.avatar{
  width: 50px;
  height: 50px;
  float: right;
}

ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  overflow: hidden;
  font-size: 20px;
}

li.nav-item {
  float: left;
}

li a, .dropbtn {
  display: inline-block;
  color: black;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
}

//li a:hover, .dropdown:hover .dropbtn {
//  //background-color: red;
//}

li.dropdown {
  display: inline-block;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
  z-index: 1;
  border-left: 8px solid #c0df17;
}

.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  text-align: left;
}

ul.sub-col-item a:hover {background-color: #f1f1f1;}

.dropdown:hover .dropdown-content {
  display: block;
  position:fixed;
}

ul.sub-col{
  min-width: 180px;
}

ul.sub-col a{
  color: #999;
  font-size: 16px;
  cursor: default;
  font-weight: bold;
}

li.sub-col-item a{
  font-size: 14px;
  color: #000;
  font-weight: normal;
}

ul.sub-col li a:hover{
  background-color: #DDD;
  color: #000;
  font-weight: bold;
}

li.sub-col-item a {
  cursor: pointer;
}
</style>
<script setup>

</script>
