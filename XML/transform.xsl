<?xml version='1.0' ?>
<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="html" doctype-system="about:legacy-compat"
  encoding="utf-8" omit-xml-declaration="yes"/>

  <xsl:template match="/">

    <xsl:variable name ="desc">
      <xsl:value-of select ="/MessageList/TraceSetDescription"/>
    </xsl:variable>

    <xsl:variable name ="descOrTime">
      <xsl:choose>
        <xsl:when test="$desc!=''">
          <xsl:value-of select = "$desc" xml:space="preserve" disable-output-escaping = "yes"/>
        </xsl:when>
        <xsl:otherwise>          
          <xsl:text xml:space="preserve">Messaging report - generated by ACSParse tool </xsl:text>
          <xsl:value-of select = "/MessageList/DateTimeStr" />
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:text disable-output-escaping = "yes">
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;
  </xsl:text>
    <head>
      <title>
        <xsl:value-of select = "$descOrTime" />
      </title>
      <link rel="stylesheet" type="text/css" href="style.css"/>
      <xsl:text disable-output-escaping = "yes">
        &lt;script type="text/javascript"&gt;
          function expandAll() {
          var details = document.getElementsByTagName("details");
          var len = details.length;
          for (var i = 0; i &lt; len; i++) {
                  if (!details[i].hasAttribute("open")) {
                      details[i].setAttribute("open", "");
                  }
              }
          };

          function collapseAll() {
              var details = document.getElementsByTagName("details");
              var len = details.length;
              for (var i = 0; i &lt; len; i++) {
                  if (details[i].hasAttribute("open")) {
                      details[i].removeAttribute("open");
                  }
              }
          };

        &lt;/script&gt;
    </xsl:text>
    </head>
    <body>
      <div class="description">
        <xsl:value-of select = "$descOrTime" disable-output-escaping = "yes"/>
        <br/>
        <br/>
        <button onclick="expandAll();">Expand all nodes</button>
        <xsl:text disable-output-escaping = "yes">&amp;nbsp;&amp;nbsp;</xsl:text>        
        <button onclick="collapseAll();">Collapse all nodes</button>
      </div>      
      <table id="acs-messages" summary="Messaging Report" width="100%">
        <thead>
          <!-- here will column names go (tpdvr, tns, ths, ...) -->
        </thead>
        <tbody>
          <!-- 
                here will messages go, positioned under it's own column (tpdvr, tns, ths, ...) 
                1 message takes all the row 
          -->
        </tbody>
      </table>

    </body>

    <xsl:text disable-output-escaping = "yes">
    &lt;/html&gt;
    </xsl:text>

  </xsl:template>

  <xsl:template name ="TMessage">

    <span class="directionSym">
      <xsl:value-of select ="DirectionText"/>
    </span>
    <span class="timestampStr">
      <xsl:value-of select ="TimestampStr"/>
    </span>
    <br/>
    <span class="caption">
      <xsl:value-of select ="Caption"/>
    </span>
    <br/>
    <details>
      <summary>
        <xsl:call-template name ="insertBreaks">
          <xsl:with-param name ="pText" select ="PreviewText"/>
        </xsl:call-template>
      </summary>
      <xsl:call-template name ="insertBreaks">
        <xsl:with-param name ="pText" select ="FullText"/>
      </xsl:call-template>
    </details>
  </xsl:template>

  <xsl:template match="text()" name="insertBreaks">
    <xsl:param name="pText" select="."/>

    <xsl:choose>
      <xsl:when test="not(contains($pText, '&#xA;'))">
        <xsl:copy-of select="$pText"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="substring-before($pText, '&#xA;')"/>
        <br />
        <xsl:call-template name="insertBreaks">
          <xsl:with-param name="pText" select=
           "substring-after($pText, '&#xA;')"/>
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>