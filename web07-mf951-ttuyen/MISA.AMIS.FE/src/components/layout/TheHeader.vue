<template >
   <div class="header">
       <div class="header-office">
           <div class="header-icon sprite icon-toggle"></div>
           <div class="header-branch-name">
               Công ty cổ phần MISA
           </div>
           <div class="header-branch-option sprite icon-chevron-down"></div>
       </div>
       <div class="header-info-account">
           <div class="announce-bell sprite icon-bell"></div>
           <div class="info-avatar sprite icon-avatar"></div>
           <div class="account-name">Trịnh Thu Uyên</div>
           <div class="account-option sprite icon-chevron-down-small"></div>
       </div>
   </div>
</template>

<script>
export default {
   name: "TheHeader",
}
</script>
<style scoped>
@import '../../css/layout/header.css'
</style>