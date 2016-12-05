<?xml version='1.0' ?>
<xsl:stylesheet version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="html" doctype-system="about:legacy-compat" 
  encoding="utf-8" omit-xml-declaration="yes"/>

  <xsl:template match="/">

  <xsl:text disable-output-escaping = "yes">
&lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;
&lt;html xmlns="http://www.w3.org/1999/xhtml"&gt;

    &lt;head&gt;
      &lt;meta http-equiv="Content-Type" content="text/html; charset=utf-8" /&gt;
      &lt;title&gt;SIP CC messages&lt;/title&gt;
      &lt;style type="text/css"&gt;
        &lt;!--
          @import url("style.css");
        --&gt;
      &lt;/style&gt;
    &lt;/head&gt;
  </xsl:text>

    <body>

          <table id="acs-messages" summary="SIP CC Messages" width="100%">
            <thead>
              <tr>
                <th scope="col">TP240Dvr</th>
                <th scope="col">TNS</th>
                <th scope="col">THS</th>
                <th scope="col">buddyconsole</th>
              </tr>
            </thead>
            <tbody>
              <xsl:for-each select ="/MessageList/Messages/Message" >
                <xsl:variable name ="sourceType" select ="SourceType"/>
                <xsl:choose>
                  <xsl:when test="$sourceType = 'Tpdrv'">
                    <tr>
                      <td>
                                                  
                            <xsl:call-template name ="TMessage">
                              <xsl:with-param name ="message" select ="."></xsl:with-param>
                            </xsl:call-template>                          
                                                
                      </td>
                      <td></td>
                      <td></td>
                      <td></td>
                    </tr>
                  </xsl:when>
                  <xsl:when test="$sourceType = 'Tns'">
                    <tr>
                      <td></td>
                      <td>
                        
                          <xsl:call-template name ="TMessage">
                            <xsl:with-param name ="message" select ="."></xsl:with-param>
                          </xsl:call-template>
                        
                      </td>
                      <td></td>
                      <td></td>
                    </tr>
                  </xsl:when>
                  <xsl:when test="$sourceType = 'Ths'">
                    <tr>
                      <td></td>
                      <td></td>
                      <td>
                        
                          <xsl:call-template name ="TMessage">
                            <xsl:with-param name ="message" select ="."></xsl:with-param>
                          </xsl:call-template>
                        
                      </td>
                      <td></td>
                    </tr>
                  </xsl:when>
                  <xsl:when test="$sourceType = 'Buddy'">
                    <tr>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td>
                          <xsl:call-template name ="TMessage">
                            <xsl:with-param name ="message" select ="."></xsl:with-param>
                          </xsl:call-template>
                      </td>
                    </tr>
                  </xsl:when>
                </xsl:choose>
              </xsl:for-each>
            </tbody>
          </table>

        </body>
   
      <xsl:text disable-output-escaping = "yes">
    &lt;/html&gt;
    </xsl:text>

  </xsl:template> 

  <xsl:template name ="TMessage">
    <b>
      <span class="directionSym">
        <xsl:value-of select ="DirectionText"/>
      </span>
    </b>
    <b>    
      <xsl:value-of select ="TimestampStr"/>
    </b>
    <br/>
    <b>
      <xsl:value-of select ="Caption"/>
    </b>
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